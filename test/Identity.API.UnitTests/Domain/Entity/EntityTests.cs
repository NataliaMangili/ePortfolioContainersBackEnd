using Identity.API.UnitTests.helpers;

namespace Identity.API.UnitTests.Domain.Entity;

public class EntityTests 
{
    [Fact]
    public void IdentityEntity_WhenSetActive_ShouldReturnTrue()
    {
        var entity = GeneratorHelper.CreateIdentityEntityGen().Generate();
        entity.SetActive();
        Assert.True(entity.Active);
    }
    
    [Fact]
    public void IdentityEntity_WhenSetInactive_ShouldReturnFalse()
    {
        var entity = GeneratorHelper.CreateIdentityEntityGen().Generate();
        entity.SetInactive();
        Assert.False(entity.Active);
    }
}