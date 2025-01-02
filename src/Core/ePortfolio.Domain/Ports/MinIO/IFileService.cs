using Microsoft.AspNetCore.Http;

namespace ePortfolio.Domain.Ports.MinIO;

public interface IFileService
{
    /// <summary>
    /// Obtém um arquivo do Minio e retorna um link.
    /// </summary>
    Task<MinioFileReturn> GetFileAsync(string objectName);

    /// <summary>
    /// Faz upload de um arquivo para o Minio.
    /// </summary>
    Task<MinioFileReturn> UploadAsync(IFormFile file);

    /// <summary>
    /// Verifica se o bucket do Minio existe e cria se necessário.
    /// </summary>
    Task EnsureBucketExistsAsync();

}


public class MinioFileReturn
{
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; }
    public string? Link { get; set; }
    public bool Success { get; set; }
}