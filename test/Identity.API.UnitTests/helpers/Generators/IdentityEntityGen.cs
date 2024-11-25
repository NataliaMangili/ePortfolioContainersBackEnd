using Bogus;
using Identity.API.Domain.Entity;


namespace Identity.API.UnitTests.helpers.Generators;

public class IdentityEntityGen :  Faker<IdentiyEntity>
{
    public IdentityEntityGen()
    {
        RuleFor(x => x.Id, f => f.Random.Guid());
        RuleFor(x => x.Inclusion,f=>DateTime.Now); 
        RuleFor(x=>x.Inclusion,f=>DateTime.Now);    
        RuleFor(x=>x.Active,f=>true);
        
    }
}