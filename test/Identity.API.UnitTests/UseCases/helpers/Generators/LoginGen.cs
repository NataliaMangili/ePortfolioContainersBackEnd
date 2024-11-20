using Bogus;
using Identity.API.UseCases.Auth.Login;

namespace Identity.API.UnitTests.UseCases.helpers.Generators;

public sealed class LoginGen: Faker<LoginIn>
{
    public LoginGen()
    {
        RuleFor(r=>r.Username, f => f.Person.UserName); 
        RuleFor(r=>r.Password,f=>f.Random.Utf16String(8));
    }
}