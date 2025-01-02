using Microsoft.Extensions.DependencyInjection;
using MongoDBDataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDataAccess;

public static class DependencyInjection
{
    //Serviços do Mongo
    public static IServiceCollection AddMongoDbServices(this IServiceCollection services, string connectionString, string databaseName)
    {
        // Registrando o MongoBaseRepository como Singleton
        services.AddSingleton<MongoBaseRepository>(sp =>
        {
            return new MongoBaseRepository(connectionString, databaseName);
        });

        services.AddScoped<MediaService>();

        return services;
    }
}
