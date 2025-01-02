using MongoDB.Driver;

namespace MongoDBDataAccess;

public class MongoBaseRepository
{
    private readonly IMongoDatabase _database;

    public MongoBaseRepository(string mongoConnectionString, string databaseName)
    {
        var client = new MongoClient(mongoConnectionString);
        _database = client.GetDatabase(databaseName);
    }

    // Salva uma lista de itens em uma coleção
    public async Task SaveItemsAsync<T>(string collectionName, IEnumerable<T> items)
    {
        var collection = _database.GetCollection<T>(collectionName);
        await collection.InsertManyAsync(items);
    }

    // Busca uma lista paginada de itens de uma coleção
    public async Task<List<T>> GetItemsPaginatedAsync<T>(
        string collectionName, int pageNumber, int pageSize)
    {
        var collection = _database.GetCollection<T>(collectionName);
        return await collection
            .Find(_ => true)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }
}