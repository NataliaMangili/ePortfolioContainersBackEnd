namespace ePortfolio.Domain.Models.ProjectAggregate;

public class Tag : Entity<Guid>
{
    public string Name { get; set; }

    public Tag(string name, Guid id, Guid userInclusionId) : base(id, userInclusionId)
    {
        Name = name;
    }

    private string SetValidateName(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, "Tag has no name");
        return name;
    }

    private Tag()
    {

    }
}