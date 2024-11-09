namespace ePortfolioContainers.UnitTests.Core.Helpers.Generator;

public class EducationGen : Faker<Education>
{
    public EducationGen()
    {
        RuleFor(x => x.Name, f => f.Company.CompanyName()); // Nome de empresa aleatório
        RuleFor(x => x.Description, f => f.Lorem.Sentence()); // Frase aleatória
        RuleFor(x => x.StartDate, f => f.Date.Past(1)); // Data no passado (até 1 ano atrás)
        RuleFor(x => x.EndDate, (f, model) => f.Date.Between(model.StartDate, DateTime.Now)); // Data final entre a data inicial e o presente
        RuleFor(x => x.UserId, f => Guid.NewGuid());
    }
}
