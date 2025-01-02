using ePortfolio.Domain.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus;
public static class DependencyInjection
{
    public static IServiceCollection AddRabbitMqEventBus(this IServiceCollection services, RabbitMqConfiguration config)
    {
        services.AddSingleton(config);
        services.AddSingleton<IEventBus, RabbitMqEventBus>();
        return services;
    }
}
