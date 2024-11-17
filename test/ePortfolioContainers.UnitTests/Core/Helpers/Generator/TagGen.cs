using ePortfolio.Domain.Models.ProjectAggregate;

namespace ePortfolioContainers.UnitTests.Core.Helpers.Generator;

public sealed class TagGen : Faker<Tag>
{
    public TagGen()
    {
        RuleFor(x => x.Id, f => Guid.NewGuid());
        RuleFor(x => x.Name, f => f.Lorem.Word());
        RuleFor(x => x.UserInclusion, f => Guid.NewGuid());
    }
}
