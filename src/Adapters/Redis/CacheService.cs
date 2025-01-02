using ePortfolio.Domain.Ports;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis;

public class CacheService(IConnectionMultiplexer connectionMultiplexer) : ICacheService
{
    private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var jsonData = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, jsonData, expiration);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var jsonData = await _database.StringGetAsync(key);
        return jsonData.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(jsonData);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<IEnumerable<string>> GetKeysAsync(string pattern)
    {
        var server = _database.Multiplexer.GetServer(_database.Multiplexer.GetEndPoints().First());
        return server.Keys(pattern: pattern).Select(k => k.ToString()).ToList();
    }

    public async Task<IEnumerable<T>> GetListAsync<T>(string key)
    {
        var list = await _database.ListRangeAsync(key);
        return list.Select(item => JsonSerializer.Deserialize<T>(item)).Where(item => item != null).ToList();
    }
}
