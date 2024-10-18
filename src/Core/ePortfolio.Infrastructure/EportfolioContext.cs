using ePortfolio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ePortfolio.Infrastructure
{
    public class EportfolioContext : DbContext
    {
        DbSet<Contact> Contacts { get; set; }   
        DbSet<Education> Educations { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Knowledge> Knowledges { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ProjectTag> ProjectsTags { get; set; }   
        
        
        private readonly IConfiguration _conf;
        public EportfolioContext(IConfiguration conf)
        {
            _conf = conf;   
        }
        
        
        
        protected  override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbConnectionString =
                _conf.GetSection("ConnectionStrings").GetSection("EportfolioDb").Value ?? string.Empty;
        
            ArgumentNullException.ThrowIfNull(dbConnectionString,"portfolio db connection string could not be found");

            options.UseNpgsql(dbConnectionString);
        }
    }
}
