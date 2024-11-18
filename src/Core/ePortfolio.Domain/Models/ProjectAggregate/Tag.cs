namespace ePortfolio.Domain.Models.ProjectAggregate;

public class Tag : Entity<Guid>
{
    public string Name { get; set; }

    public Tag(string name, Guid userInclusionId) : base(Guid.NewGuid(), userInclusionId)
    {
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