using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;

namespace MinIOStorage
{
    public class ImageService
    {
        private readonly MinioClient _minioClient;
        private readonly string _bucketName;

        public ImageService(IConfiguration configuration)
        {
            _bucketName = configuration["Minio:BucketName"] ?? throw new InvalidOperationException("Bucket name config is missing");

            var minioConfig = configuration.GetSection("Minio");
            var endpoint = minioConfig["Endpoint"];
            var accessKey = minioConfig["AccessKey"];
            var secretKey = minioConfig["SecretKey"];
            var secure = bool.Parse(minioConfig["UseSSL"]);

            _minioClient = (MinioClient?)new MinioClient()
                .WithEndpoint(endpoint)
                .WithCredentials(accessKey, secretKey)
                .WithSSL(secure)
                .Build();
        }

        /// <summary>
        /// Obtém um arquivo do Minio e retorna um link
        /// </summary>
        /// <param name="objectName">Nome do objeto no Minio.</param>
        public async Task<File> GetFileAsync(string objectName)
        {
            if (string.IsNullOrWhiteSpace(objectName))
                throw new ArgumentException("Object name cannot be null or empty.", nameof(objectName));

            try
            {
                var args = new PresignedGetObjectArgs()
                    .WithObject(objectName)
                    .WithBucket(_bucketName)
                    .WithExpiry(900); // 15 minutos

                var presignedUrl = await _minioClient.PresignedGetObjectAsync(args).ConfigureAwait(false);

                return new File { Link = presignedUrl, Sucesso = true };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error getting file {objectName}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Faz upload de um arquivo para o Minio.
        /// </summary>
        /// <param name="file">Arquivo para upload.</param>
        public async Task<File> UploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File cannot be null or empty.", nameof(file));

            try
            {
                var objectName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName).ToLower()}";

                using var stream = file.OpenReadStream();

                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(objectName)
                    .WithStreamData(stream)
                    .WithObjectSize(stream.Length)
                    .WithContentType(file.ContentType);

                await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);

                return new File
                {
                    Nome = objectName,
                    Tamanho = (int)stream.Length,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error uploading file: {ex.Message}", ex);
            }
        }
    }

    public class File
    {
        public string Nome { get; set; } = string.Empty;
        public int Tamanho { get; set; }
        public string? Link { get; set; }
        public bool? Sucesso { get; set; }
    }
}
