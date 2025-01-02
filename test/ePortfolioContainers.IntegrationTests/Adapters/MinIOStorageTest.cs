using FluentAssertions;
using Microsoft.AspNetCore.Http;
using MinIOStorage;
using MinIOStorage.Tests;

namespace ePortfolioContainers.IntegrationTests.Adapters;

public class ImageServiceIntegrationTests : IntegrationTestBase, IClassFixture<MinioFixture>
{
    private readonly MinioFixture _fixture;

    public ImageServiceIntegrationTests(MinioFixture fixture)
    {
        _fixture = fixture;

        // Criar o bucket no MinIO antes dos testes | Olhar depois
        var imageService = new FileService(_fixture.Configuration);
        imageService.EnsureBucketExistsAsync().Wait();
    }

    [Fact]
    public async Task UploadAsync_ShouldUploadFileSuccessfully()
    {
        // Arrange
        IFormFile file = CreateFormFile("Content", "test-file.txt");
        FileService imageService = new(_fixture.Configuration);

        // Act
        var result = await imageService.UploadAsync(file);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Name.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GetFileAsync_ShouldReturnPresignedUrl()
    {
        // Arrange
        IFormFile file = CreateFormFile("Content", "test-file.txt");
        FileService imageService = new(_fixture.Configuration);

        var uploadResult = await imageService.UploadAsync(file);

        // Act
        var result = await imageService.GetFileAsync(uploadResult.Name);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Link.Should().NotBeNullOrWhiteSpace();

    }

    [Fact]
    public async Task GetFileAsync_ShouldReturnPresignedUrl_Valid()
    {
        // Arrange
        IFormFile file = CreateFormFile("Content", "test-file.txt");
        FileService imageService = new(_fixture.Configuration);

        var uploadResult = await imageService.UploadAsync(file);
        var result = await imageService.GetFileAsync(uploadResult.Name);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Link.Should().NotBeNullOrWhiteSpace();

        // TODO: Validar se o link gerado é acessível usando HttpClient
        //var httpClient = new HttpClient();
        //var response = await httpClient.GetAsync(result.Link);

        //response.IsSuccessStatusCode.Should().BeTrue();
        //response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }
}