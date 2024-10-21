using Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Data;

public class IdentityContext(DbContextOptions<IdentityContext> options, IConfiguration conf)
    : IdentityDbContext<User>(options)
{
    protected  override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var dbConnectionString =
            conf.GetSection("ConnectionStrings").GetSection("IdentityDb").Value ?? string.Empty;
        ArgumentException.ThrowIfNullOrEmpty(dbConnectionString,"IdentityDb connection string could not be found");
        
        options.UseNpgsql(dbConnectionString);
    }
}