﻿using Identity.API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityDataAcess;

public class AuthRepository<TIdentityContext, TUserManager>(TIdentityContext identityContext, TUserManager userManager)
    : IAuthRepository
    where TIdentityContext : IdentityDbContext
    where TUserManager : UserManager<IdentityUser>
{
    public async Task<bool> IsUserPasswordValid(string username, string password)
    {
        try
        {
            ArgumentException.ThrowIfNullOrEmpty(username, "Username not provided ");
            ArgumentException.ThrowIfNullOrEmpty(password, "Password not provided ");

            var user = await userManager.FindByNameAsync(username);

            ArgumentNullException.ThrowIfNull(user, "User not found ");

            return await userManager.CheckPasswordAsync(user, password);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}