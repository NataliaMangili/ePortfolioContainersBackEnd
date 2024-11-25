using Identity.API.UnitTests.helpers.Generators;
using Identity.API.UnitTests.UseCases.helpers.Generators;

namespace Identity.API.UnitTests.helpers;

public static class GeneratorHelper
{
    public static LoginGen CreateLoginGen() => new();
    public static IdentityEntityGen CreateIdentityEntityGen() => new();


}