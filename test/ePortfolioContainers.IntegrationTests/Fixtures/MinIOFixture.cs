using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Microsoft.Extensions.Configuration;

namespace MinIOStorage.Tests;

public class MinioFixture : IAsyncLifetime
{
    public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; private set; }
    public static string BucketName => "test-bucket";

    private IContainer _minioContainer;

    public async Task InitializeAsync()
    {
        // Criando um container do MinIO
        _minioContainer = new ContainerBuilder()
            .WithImage("minio/minio:latest")
            .WithCommand("server")
            .WithPortBinding(9004, 11111) // Porta 9002 mapeada para 11111
            .WithEnvironment("MINIO_ROOT_USER", "admin")
            .WithEnvironment("MINIO_ROOT_PASSWORD", "admin1234")
            //.WithNetwork("eportfolio.net")
            .Build();

        await _minioContainer.StartAsync();

        var hostPort = _minioContainer.GetMappedPublicPort(11111);  // Mapeado 9002 -> 11111

        // Configs do MinIO
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddInMemoryCollection(
        [
        new KeyValuePair<string, string>("Minio:Endpoint", $"minio:{hostPort}"),  // Usando o host mapeado corretamente
        new KeyValuePair<string, string>("Minio:AccessKey", "admin"),
        new KeyValuePair<string, string>("Minio:SecretKey", "admin1234"),
        new KeyValuePair<string, string>("Minio:UseSSL", "false"),
        new KeyValuePair<string, string>("Minio:BucketName", BucketName)
        ]);

        Configuration = configurationBuilder.Build();
    }

    public async Task DisposeAsync()
    {
        await _minioContainer.DisposeAsync();
    }
}