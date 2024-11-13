namespace ePortfolioContainers.UnitTests.Core.Helpers.Generator;

public class KnowledgeGen: Faker<Knowledge>
{
    public KnowledgeGen()
    {
        RuleFor(r=>r.Id,Guid.NewGuid);
        RuleFor(r=>r.Name,f=>f.Company.CompanyName());          
        RuleFor(r=>r.Description,f=>f.Company.CompanyName());   
        RuleFor(r=>r.Time,f=>f.Date.Past());
        RuleFor(r=>r.Learning,r=>r.Random.Bool());
        RuleFor(r => r.ImageId, Guid.NewGuid);

    }
}