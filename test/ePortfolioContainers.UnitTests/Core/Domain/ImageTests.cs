using ePortfolioContainers.UnitTests.Core.Helpers.Generator;

namespace ePortfolioContainers.UnitTests.Core.Domain;

public class ImageTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    private void SetName_InvalidName_ThrowsArgumentException(string name)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        
        Action act = () => image.SetName(name); 
        
        Assert.Throws<ArgumentException>(act);   
        
    }
    
    [Theory]
    [InlineData("file.png")]
    private void SetName_ValidName_DoesNotThrow(string name)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();

        image.SetName(name); 
        
        Assert.Equal(image.Name,name);   
        
    }
    
    
    //Todo: validar SetUrl
    
}
