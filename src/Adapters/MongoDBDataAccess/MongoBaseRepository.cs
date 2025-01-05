using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

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
        // Cria a coleção se não existir
        await VerifyCollectionExistsAsync<T>(collectionName);

        var collection = _database.GetCollection<T>(collectionName);
        await collection.InsertManyAsync(items);
    }

    // Busca uma lista paginada de itens de uma coleção
    public async Task<List<T>> GetItemsPaginatedAsync<T>(string collectionName, int pageNumber, int pageSize, Expression<Func<T, bool>>? filter = null)
    {
        IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);

        // Aplica o filtro se houver
        var query = collection.Find(filter ?? (_ => true));

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync<T>(string collectionName)
    {
        IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
        return (int)await collection.CountDocumentsAsync(_ => true);
    }

    private async Task VerifyCollectionExistsAsync<T>(string collectionName)
    {
        var filter = new BsonDocument("name", collectionName);
        var options = new ListCollectionsOptions { Filter = filter };

        using (var cursor = await _database.ListCollectionsAsync(options))
        {
            if (!await cursor.AnyAsync())
            {
                await _database.CreateCollectionAsync(collectionName);
            }
        }
    }
}