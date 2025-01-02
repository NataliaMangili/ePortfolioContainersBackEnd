using Identity.API.Domain.User;
using Identity.API.Infrastructure.User;
using Identity.API.UnitTests.helpers;
using Identity.API.UnitTests.UseCases.helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Moq;
using Tests.Building.Blocks.Helpers;

namespace Identity.API.UnitTests.Repositories;

public class UserRepositoryTests:InMemoryDatabaseHelper<IdentityDbContext<User>>
{
    [Fact]
    public async Task IsUserPasswordValid_WhenIsIncorrect_ReturnsFalse()
    {
        var mockUserManager = IdentityHelper.MockUserManager<User>(new List<User>());
        mockUserManager.Setup(s => s.CheckPasswordAsync(It.IsAny<User>(),It.IsAny<string>())).ReturnsAsync(false);
        mockUserManager.Setup(s => s.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new User());
        var userRepo = new UserRepository<IdentityDbContext<User>, UserManager<User>, User>(InMemoryContext,mockUserManager.Object);

        var result = await userRepo.IsUserPasswordValid("test", "test");
        Assert.False(result);

    }
    
    [Theory]
    [InlineData("","")]
    public async Task IsUserPasswordValid_WhenIsInvalid_ThrowsArgumentNullException( string username, string password)
    {
        var mockUserManager = IdentityHelper.MockUserManager<User>(new List<User>());
        var userRepo = new UserRepository<IdentityDbContext<User>, UserManager<User>, User>(InMemoryContext,mockUserManager.Object);

        await Assert.ThrowsAsync<ArgumentException>(async () => await userRepo.IsUserPasswordValid(username, password));
    }

    [Fact]
    public async Task IsUserPasswordValid_WhenUserNotFound_ThrowsArgumentNullException()
    {
        var mockUserManager = IdentityHelper.MockUserManager<User>(new List<User>());
        var userRepo = new UserRepository<IdentityDbContext<User>, UserManager<User>, User>(InMemoryContext,mockUserManager.Object);
        
        mockUserManager.Setup(s=>s.FindByNameAsync(It.IsAny<string>())).ReturnsAsync((User)null); 
        
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await userRepo.IsUserPasswordValid("username", "password"));
        
    }


    [Fact]
    public async Task CreateUser_WhenUserNotExists_ReturnsIdentiyResultSucess()
    {
        var mockUserManager = IdentityHelper.MockUserManager<User>(new List<User>());
        var userRepo = new UserRepository<IdentityDbContext<User>, UserManager<User>, User>(InMemoryContext,mockUserManager.Object);
        
        mockUserManager.Setup(s=>s.FindByNameAsync(It.IsAny<string>())).ReturnsAsync((User)null);   
        mockUserManager.Setup(s => s.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

        User user = new()
        {
            Id = Guid.NewGuid().ToString(),
            Email = "some@mail.com",
            UserName = "SomeUser",
        };
        
        var result = await userRepo.CreateUser(user,"somePassword");
        
        Assert.NotNull(result); 
        Assert.Equal(IdentityResult.Success, result);
    }
    // [Fact]
    // public async Task CreateUser_WhenUserExists_ReturnsUser()   
    
    
}