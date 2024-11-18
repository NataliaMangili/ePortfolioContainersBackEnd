using System.Text;
using ePortfolioContainers.UnitTests.Core.Helpers;

namespace ePortfolioContainers.UnitTests.Core.Domain;

public class KnowledgeTests
{
    [Fact]
    public void SetName_EmptyName_ThrowsArgumentException()
    {
        var validKnow  = GeneratorHelper.CreateKnowledgeGen().Generate();
        Action act = () => validKnow.SetName(string.Empty);
        Assert.Throws<ArgumentException>(act);  
    }
    
    [Theory]
    [InlineData("University Name")]
    public void SetName_ValidName_DoesNotThrow(string name)
    {
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();
        validKnow.SetName(name);
        
        Assert.Equal(validKnow.Name,name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void SetDescription_InvalidDescription_ThrowsArgumentException(string description)
    {
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();
        Action act = () => validKnow.SetDescription(description);   
        
        Assert.Throws<ArgumentException>(act);  
    }

    [Fact]
    public void SetDescription_DescriptionLargerThan500_throwsArgumentException()
    {
        var sb = new StringBuilder();
        for (int    i = 0; i < 501; i++)
        {
            sb.Append('a');
        }
            
        string description = sb.ToString();
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();
        Action act = () => validKnow.SetDescription(description);   
        
        Assert.Throws<ArgumentException>(act);  
    }

    [Fact]
    public void SetDescription_ValidDescription_DoesNotThrow()
    {
        string description = "What you did in learning";
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();
        validKnow.SetDescription(description);
        Assert.Equal(validKnow.Description,description);
    }
    
    [Fact]
    public void SetTime_InvalidTime_ThrowsArgumentException()
    {
        DateTime time = DateTime.Now.AddYears(1);
        
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();    
        Action act = () => validKnow.SetValidateTime(time);
        
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void SetTime_ValidTime_DoesNotThrow()
    {
        DateTime time = DateTime.Now;
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();
        validKnow.SetValidateTime(time);
        
        Assert.Equal(validKnow.Time,time);
    }

    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void SetImageId_InvalidImageId_ThrowsArgumentException(string id)
    {
        Guid imageId = Guid.Parse(id);
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();    
        Action act =()=> validKnow.SetImageId(imageId);
        
        Assert.Throws<ArgumentException>(act);  
    }

    [Fact]
    public void SetImageId_ValidImageId_DoesNotThrow()
    {
        Guid imageId = Guid.NewGuid();
        var validKnow = GeneratorHelper.CreateKnowledgeGen().Generate();
        validKnow.SetImageId(imageId);
        
        Assert.Equal(validKnow.ImageId,imageId);    
    }
    
    
    
    
    
    
    
}