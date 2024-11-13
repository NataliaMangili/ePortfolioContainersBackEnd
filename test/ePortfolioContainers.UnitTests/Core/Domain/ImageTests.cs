using ePortfolioContainers.UnitTests.Core.Helpers.Generator;

namespace ePortfolioContainers.UnitTests.Core.Domain;

public class ImageTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("file")]
    public void SetName_InvalidName_ThrowsArgumentException(string name)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        
        Action act = () => image.SetName(name); 
        
        Assert.Throws<ArgumentException>(act);   
        
    }
    
    [Theory]
    [InlineData("file.png")]
    public void SetName_ValidName_DoesNotThrow(string name)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();

        image.SetName(name); 
        
        Assert.Equal(image.Name,name);   
        
    }

    [Theory]
    [InlineData("")]
    [InlineData("google.com")]
    public void SetUrl_InvalidUrl_ThrowsArgumentException(string url)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        Action act = () => image.SetUrl(url);

        Assert.Throws<ArgumentException>(act);
    }
    
    [Theory]
    [InlineData("")]
    public void SetUrl_EmptyUrl_ThrowsArgumentException(string url)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        Action act = () => image.SetUrl(url);

        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData("/dir/file.png")]
    public void SetUrl_ValidUrl_DoesNotThrow(string url)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        image.SetUrl(url);  
        Assert.Equal(image.Url,url);    
    }

    [Fact]
    public void FileExtersion_ValidFileName_DoesNotThrow()
    {
        var image = GeneratorHelper.CreateImageGen().Generate();    
        image.SetName("file.png");
        Assert.Equal("png",image.FileExtension);
    }
    
    
    
    
    
    
    
}
