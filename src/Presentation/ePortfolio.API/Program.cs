using ePortfolio.API.Identity;
using ePortfolio.Application;
using ePortfolio.Application.Ports;
using ePortfolio.Infrastructure;
using ePortfolio.Infrastructure.Middleware;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostgreDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EportfolioContext>();


builder.Services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));

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
