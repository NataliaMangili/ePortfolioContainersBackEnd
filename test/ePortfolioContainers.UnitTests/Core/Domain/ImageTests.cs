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
    [InlineData(null)]
    public void SetPath_EmptyPath_ThrowsArgumentException(string path)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        Action act = () => image.SetPath(path);

        Assert.Throws<ArgumentNullException>(act);
    }

    [Theory]
    [InlineData("/dir/file.png")]
    public void SetPath_ValidPath_DoesNotThrow(string filePath)
    {
        var image = GeneratorHelper.CreateImageGen().Generate();
        image.SetPath(filePath);  
        Assert.Equal(image.Path,filePath);    
    }
    
    [Fact]
    public void SetPath_InvalidPath_ThrowsArgumentException()
    {
        string path = "dir";
        var image = GeneratorHelper.CreateImageGen().Generate();
        Action act = () => image.SetPath(path);

        Assert.Throws<ArgumentException>(act);
    }
 

    [Fact]
    public void FileExtersion_ValidFileName_DoesNotThrow()
    {
        var image = GeneratorHelper.CreateImageGen().Generate();    
        image.SetName("file.png");
        Assert.Equal("png",image.FileExtension);
    }
    
    
    
    
    
    
    
}
