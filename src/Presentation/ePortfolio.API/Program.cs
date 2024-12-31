using ePortfolio.Application;
using ePortfolio.Domain.Ports;
using ePortfolio.Infrastructure;
using ePortfolio.Infrastructure.Middleware;
using EventBus;
using Microsoft.EntityFrameworkCore;
using Minio;
using MinIOStorage;
using PostgreDataAccess;
using Redis;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EportfolioContext>(options =>
    {  
        var dbConnectionString =
            builder.Configuration
                   .GetSection("ConnectionStrings")
                   .GetSection("EportfolioDb")
                   .Value ?? string.Empty;
        
        ArgumentNullException.ThrowIfNull(dbConnectionString,"portfolio db connection string could not be found");

        options.UseNpgsql(dbConnectionString);
    }
);

builder.Services.AddSingleton(_ =>
    new MinioClient()
        .WithEndpoint(configuration["Minio:Endpoint"])
        .WithCredentials(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"])
        .WithSSL(bool.Parse(configuration["Minio:UseSSL"]))
        .Build());

builder.Services.AddScoped<ImageService>();

var rabbitMqConfig = new RabbitMqConfiguration
{
    HostName = builder.Configuration["RabbitMq:HostName"],
    Port = int.Parse(builder.Configuration["RabbitMq:Port"]),
    ExchangeName = builder.Configuration["RabbitMq:ExchangeName"]
};

// Registrar os Adapters
builder.Services.AddRabbitMqEventBus(rabbitMqConfig);
builder.Services.AddRedisCache(builder.Configuration.GetConnectionString("Redis"));


builder.Services.AddScoped(typeof(IWriteRepository<,,>), typeof(WriteRepository<,,>));

var application = typeof(IAssemblyMark);
builder.Services.AddMediatR(configure =>
{
    configure.RegisterServicesFromAssembly(application.Assembly);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandling>();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EportfolioContext>();
    db.Database.Migrate();
}

app.Run();
