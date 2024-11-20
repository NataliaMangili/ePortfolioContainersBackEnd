using ePortfolio.API.Identity;
using ePortfolio.Application.Ports;
using ePortfolio.Infrastructure;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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


// builder.Services.AddTransient<IIdentityService, IdentityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EportfolioContext>();
    db.Database.Migrate();
}


app.Run();
