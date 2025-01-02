using ePortfolio.Domain.Ports.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using MongoDBDataAccess.Services;

namespace MongoDBDataAccess;

public static class DependencyInjection
{
    //Serviços do Mongo
    public static IServiceCollection AddMongoDbServices(this IServiceCollection services, MongoSettings mongoConfig)
    {
        // Registrando o MongoBaseRepository como Singleton
        services.AddSingleton<MongoBaseRepository>(sp =>
        {
            return new (mongoConfig.MongoConnectionString, mongoConfig.DatabaseName);
        });

        services.AddScoped<IMediaService, MediaService>();

        return services;
    }
}
