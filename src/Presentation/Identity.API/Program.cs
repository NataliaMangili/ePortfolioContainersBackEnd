using Identity.API.Domain.Auth;
using Identity.API.Domain.User;
using Identity.API.Infrastructure;
using Identity.API.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthRepository<User>, AuthRepository<IdentityContext, UserManager<User>, User>>();
builder.Services.AddDbContext<IdentityContext>();
builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()   
    .AddDefaultTokenProviders();

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

app.Run();
