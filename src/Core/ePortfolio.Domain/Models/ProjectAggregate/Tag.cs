namespace ePortfolio.Domain.Models.ProjectAggregate;

public class Tag : Entity<Guid>
{
    public string Name { get; set; }

    public Tag(string name, Guid userInclusionId) : base(Guid.NewGuid(), userInclusionId)
    {
        SetValidateName(name);
        UserInclusion = userInclusionId;
    }

    public void SetValidateName(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, "Tag has no name");
        Name = name;
    }

    public Tag()
    {

    }
}