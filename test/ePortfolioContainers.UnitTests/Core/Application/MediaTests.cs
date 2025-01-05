using ePortfolio.Domain.Ports.MongoDB;
using Moq;

namespace ePortfolioContainers.UnitTests.Core.Domain;

public class MediaServiceTests
{
    private readonly Mock<IMediaService> _mockMediaService;

    public MediaServiceTests() => _mockMediaService = new Mock<IMediaService>();

    [Fact]
    public async Task SaveMediaItemsAsync_ShouldCallRepositorySaveMethod()
    {
        // Arrange
        List<MediaItem> mediaItems = CreateMediaItemList();

        _mockMediaService.Setup(repo => repo.SaveMediaItemsAsync(It.IsAny<IEnumerable<MediaItem>>()));
            //.Returns(Task.CompletedTask);

        // Act
        await _mockMediaService.Object.SaveMediaItemsAsync(mediaItems);

        // Assert
        _mockMediaService.Verify(repo => repo.SaveMediaItemsAsync(It.IsAny<IEnumerable<MediaItem>>()), Times.Once);
    }

    [Fact]
    public async Task GetMediaItemsPaginatedAsync_ShouldReturnExpectedItems()
    {
        // Arrange
        List<MediaItem> expectedItems = CreateMediaItemList();

        _mockMediaService.Setup(repo => repo.GetMediaItemsPaginatedAsync(1, 2))
            .ReturnsAsync(expectedItems);

        // Act
        List<MediaItem> result = await _mockMediaService.Object.GetMediaItemsPaginatedAsync(1, 2);

        // Assert
        Assert.Equal(expectedItems.Count, result.Count);
        Assert.Equal(expectedItems[0].Name, result[0].Name);
    }

    [Fact]
    public async Task GetMediaItemsPaginatedAsync_ShouldHandleEmptyResult()
    {
        // Arrange
        var emptyItems = new List<MediaItem>();

        _mockMediaService.Setup(repo => repo.GetMediaItemsPaginatedAsync(1, 2))
            .ReturnsAsync(emptyItems);

        // Act
        List<MediaItem> result = await _mockMediaService.Object.GetMediaItemsPaginatedAsync(1, 2);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }



    private static List<MediaItem> CreateMediaItemList()
    {
        return
            [
                new() { Id = "1", Name = "Media 1", Url = "http://test.com/1", Type = "image", CreatedAt = System.DateTime.UtcNow, Size = 100 },
                new() { Id = "2", Name = "Media 2", Url = "http://test.com/2", Type = "video", CreatedAt = System.DateTime.UtcNow, Size = 200 }
            ];
    }
}