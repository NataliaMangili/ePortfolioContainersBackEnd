using ePortfolio.Domain.Ports;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Redis;

public static class DependencyInjection
{
    public static IServiceCollection AddRedisCache(this IServiceCollection services, string connectionString)
    {
        // Configurando o Redis ConnectionMultiplexer
        services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            return ConnectionMultiplexer.Connect(connectionString);
        });

        // Registrando o CacheService com a interface ICacheService
        services.AddSingleton<ICacheService, CacheService>();

        return services;
    }
}
