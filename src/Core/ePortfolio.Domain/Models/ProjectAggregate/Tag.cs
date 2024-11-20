namespace ePortfolio.Domain.Models.ProjectAggregate;

public class Tag : Entity<Guid>
{
    public string Name { get; set; }

    public Tag(Guid tagId, string name, Guid userInclusionId) : base(tagId, userInclusionId)
    {
        Id = tagId;
        Name = name;
        UserInclusion = userInclusionId;
    }

    private string SetValidateName(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, "Tag has no name");
        return name;
    }

    public Tag()
    {

    }
}