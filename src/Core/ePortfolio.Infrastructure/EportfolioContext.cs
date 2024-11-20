using ePortfolio.Domain.Models;
using ePortfolio.Domain.Models.ProjectAggregate;
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
        
        public EportfolioContext(DbContextOptions<EportfolioContext> options) : base(options)
        {
        }
        
        public EportfolioContext()
        {
               
        }
        
    }
}
