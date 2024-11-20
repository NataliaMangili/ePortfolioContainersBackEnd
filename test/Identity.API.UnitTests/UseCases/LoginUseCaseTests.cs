using Identity.API.UnitTests.UseCases.helpers;
using Identity.API.UseCases.Auth.Login;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tests.Building.Blocks.Helpers;

namespace Identity.API.UnitTests.UseCases;

public class LoginUseCaseTests : InMemoryDatabaseHelper<IdentityDbContext>
{
    [Theory]
    [InlineData("user", "pass")]
    public async Task Login_ValidInput_AcessToken(string username, string password)
    {
    }
    
    
    [Fact]
    public async Task Login_WhenUserNotFound_ThrowsException()
    {
        LoginIn request = GeneratorHelper.CreateLoginGen().Generate();
        
        

    }
}