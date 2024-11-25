
using Identity.API.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 

namespace Identity.API.Infrastructure;

public class IdentityContext(DbContextOptions<IdentityContext> options, IConfiguration conf)
    : IdentityDbContext<Domain.User.User,Roles,Guid>(options)
{
    protected  override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var dbConnectionString =
            conf.GetSection("ConnectionStrings").GetSection("IdentityDb").Value ?? string.Empty;
        ArgumentException.ThrowIfNullOrEmpty(dbConnectionString,"IdentityDb connection string could not be found");
        
        options.UseNpgsql(dbConnectionString);
    }
}