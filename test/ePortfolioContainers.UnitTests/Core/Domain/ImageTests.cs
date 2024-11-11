using ePortfolioContainers.UnitTests.Core.Helpers.Generator;

namespace ePortfolioContainers.UnitTests.Core.Domain;

public class ImageTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("file")]
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

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("google.com")]
    [InlineData("http://www.google")]
    private void SetUrl_InvalidUrl_ThrowsUriFormatException(string url)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        Action act = () => image.SetUrl(url);

        Assert.Throws<UriFormatException>(act);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]

    private void SetUrl_EmptyUrl_ThrowsUriFormatException(string url)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        Action act = () => image.SetUrl(url);

        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData("/dir/file.png")]
    private void SetUrl_ValidUrl_DoesNotThrow(string url)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        image.SetUrl(url);  
        Assert.Equal(image.Url,url);    
    }

    [Fact]
    private void FileExtersion_ValidFileName_DoesNotThrow()
    {
        var image = GeneratorHelper.CreateImageGen().Generate();    
        image.SetName("file.png");
        Assert.Equal("png",image.FileExtension);
    }
    
    
    
    
    
    
    
}
