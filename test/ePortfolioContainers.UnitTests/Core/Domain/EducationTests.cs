namespace ePortfolioContainers.UnitTests.Core.Domain;

public class EducationTests
{
    private Education CreateValidEducation()
        => new Education(Guid.NewGuid(),
                        "New Education",
                        "Education for tests",
                        DateTime.Now,
                        DateTime.Now,
                        Guid.NewGuid(),
                        Guid.NewGuid());

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void SetName_InvalidName_ThrowsArgumentException(string invalidName)
    {
        var education = CreateValidEducation();

        Action act = () => education.SetName(invalidName);
        
        Assert.Throws<ArgumentException>(act);  
    }

    [Theory]
    [InlineData("University")]
    public void SetName_ValidName_DoesNotThrow(string name)
    {
        var education = CreateValidEducation();
        
        education.SetName(name); 
        
        Assert.Equal(name, education.Name); 
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void SetDescrition_InvalidDescription_ThrowsArgumentException(string invalidDescription)
    {
        var education = CreateValidEducation();
        Action act = () => education.SetDescription(invalidDescription);  
        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData("The course that I did")]
    public void SetDescription_ValidDescription_DoesNotThrow(string description)
    {
        var education = CreateValidEducation();
        education.SetDescription(description) ;
        Assert.Equal(description, education.Description);   
    }
    
    [Theory]
    [InlineData("01-01-2025","01-01-2024")]
    public void SetDates_InvalidDate_ThrowsArgumentException(string startDate, string endDate)
    {
        var education = CreateValidEducation();
        
        Action act = () => education.SetDates(DateTime.Parse(startDate), DateTime.Parse(endDate));

        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData("01-01-2024", "01-01-2025")]
    public void SetDates_ValidDates_DoesNotThrow(string initial, string last)
    {
        var education = CreateValidEducation();

        var startDate = DateTime.Parse(initial);
        var endDate = DateTime.Parse(last); 
        
        education.SetDates(startDate, endDate);
        
        Assert.Equal(startDate,education.StartDate);
        Assert.Equal(endDate,education.EndDate);    
        
    }
    
}
                