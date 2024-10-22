using Identity.API.Data;
using Identity.API.Interfaces;
// using Identity.API.Interfaces;
using Identity.API.Models;
using Identity.API.UseCases;
using IdentityDataAcess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Todo : declarar de forma correta o usuário para injecção do adaptador do identity
// builder.Services.AddScoped(typeof(IAuthRepository), typeof(AuthRepository<IdentityContext,UserManager<User>,User>));    

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
