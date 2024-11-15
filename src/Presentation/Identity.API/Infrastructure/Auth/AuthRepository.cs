using Identity.API.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.API.Infrastructure.Auth;

public class AuthRepository<TIdentityContext, TUserManager,TUser>(TIdentityContext identityContext, TUserManager userManager)
    :IAuthRepository<TUser>
    where TIdentityContext : IdentityDbContext<TUser>
    where TUserManager : UserManager<TUser>
    where TUser : IdentityUser  
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

 
    public async  Task<IdentityResult> CreateUser(TUser user, string password)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(user, "Username not provided ");
            ArgumentException.ThrowIfNullOrEmpty(password, "Password not provided ");
            
            return await userManager.CreateAsync(user, password);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
        
    }
}