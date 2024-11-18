using System.ComponentModel.DataAnnotations.Schema;

namespace ePortfolio.Domain.Models.ProjectAggregate;

public class ProjectTag : Entity<Guid>
{
    [ForeignKey("Project")]
    public Guid ProjectId { get; set; }
    public virtual Project Project { get; set; }

    [ForeignKey("Tag")]
    public Guid TagId { get; set; }
    public virtual Tag Tag { get; set; }

    public ProjectTag(Guid projectId, Guid tagId, Guid userInclusion) : base(Guid.NewGuid(), userInclusion)
    {
        ProjectId = projectId;
        TagId = tagId;
    }

    public ProjectTag()
    {

    }
}