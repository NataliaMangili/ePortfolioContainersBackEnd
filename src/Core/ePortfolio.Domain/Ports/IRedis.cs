namespace ePortfolio.Domain.Ports;

public interface ICacheService
{
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
    Task<T> GetAsync<T>(string key);
    Task<bool> RemoveAsync(string key);
    Task<IEnumerable<string>> GetKeysAsync(string pattern);
    Task<IEnumerable<T>> GetListAsync<T>(string key);
}