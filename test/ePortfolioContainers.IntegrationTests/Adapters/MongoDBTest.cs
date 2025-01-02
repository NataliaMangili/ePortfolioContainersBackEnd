using Mongo2Go;
using MongoDBDataAccess;

namespace ePortfolioContainers.IntegrationTests.Adapters;

public class MongoDBTest : IDisposable
{
    private readonly MongoDbRunner _runner;
    private readonly MongoBaseRepository _repository;
    private static readonly string collectionTest = "TestMediaCollection";

    public MongoDBTest()
    {
        // Inicia o MongoDB em memória
        _runner = MongoDbRunner.Start();

        // String de conexão em memória
        _repository = new MongoBaseRepository(_runner.ConnectionString, "TestDatabase");

    }

    void IDisposable.Dispose() => _runner.Dispose();

    [Fact]
    public async Task SaveItemsAsync_ShouldSaveItemsToCollection()
    {
        // Arrange
        var items = new List<TestItem>
        {
            new() { Id = "1", Name = "Item1" },
            new() { Id = "2", Name = "Item2" }
        };
        await _repository.SaveItemsAsync(collectionTest, items);

        // Act
        Task<List<TestItem>> collection = _repository.GetItemsPaginatedAsync<TestItem>(collectionTest, 1, 10);

        // Assert
        Assert.Equal(2, (await collection).Count);
    }

    [Fact]
    public async Task GetItemsPaginatedAsync_ShouldReturnPaginatedItems()
    {
        // Arrange
        IEnumerable<TestItem> items = Enumerable.Range(1, 20)
        .Select(i => new TestItem { Id = i.ToString(), Name = $"Item{i}" });

        await _repository.SaveItemsAsync(collectionTest, items);

        // Act
        List<TestItem> paginatedItems = await _repository.GetItemsPaginatedAsync<TestItem>(collectionTest, pageNumber: 2, pageSize: 5);

        // Assert
        Assert.Equal(5, paginatedItems.Count);
        Assert.Equal("Item6", paginatedItems.First().Name);
    }

    private class TestItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}