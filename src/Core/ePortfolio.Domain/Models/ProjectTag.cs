using System.ComponentModel.DataAnnotations.Schema;

namespace ePortfolio.Domain.Models;

public class ProjectTag : Entity<Guid>
{
    [ForeignKey("Project")]
    public Guid ProjectId { get; set; } 
    public virtual Project Project { get; set; }    
    
    [ForeignKey("Tag")]
    public Guid TagId { get; set; } 
    public virtual Tag Tag { get; set; }

    public ProjectTag(Guid projectId, Guid tagId , Guid id, Guid userInclusionId):base(id, userInclusionId) 
    {
        ProjectId = projectId;  
        TagId = tagId;  
    }
}