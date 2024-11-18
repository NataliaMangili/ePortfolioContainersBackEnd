using ePortfolio.Domain.Models.ProjectAggregate;

namespace ePortfolioContainers.UnitTests.Core.Helpers.Generator;

public sealed class ProjectGen : Faker<Project>
{
    public ProjectGen()
    {
        RuleFor(x => x.Id, f => Guid.NewGuid());
        RuleFor(x => x.Title, f => f.Lorem.Word());
        RuleFor(x => x.HtmlDescription, f => f.Lorem.Sentence()); // Frase aleatória
        RuleFor(x => x.Order, f => f.Random.Number(1, 200)); // Número aleatório entre 1 e 200
        RuleFor(x => x.UserInclusion, f => Guid.NewGuid());
        //RuleFor(x => x.EProject, f => f.Random.Number(2));
    }
}
