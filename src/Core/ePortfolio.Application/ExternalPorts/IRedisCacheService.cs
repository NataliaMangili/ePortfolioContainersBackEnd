namespace ePortfolio.Application.ExternalPorts;

public interface IRedisCacheService
{
    // Armazena um valor associado a uma chave no cache.
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);

    // Recupera um valor associado a uma chave do cache.
    Task<T> GetAsync<T>(string key);

    // Remove um item do cache com base na chave.
    Task<bool> RemoveAsync(string key);

    // Obtém todas as chaves que correspondem a um padrão.
    Task<IEnumerable<string>> GetKeysAsync(string pattern);
}
