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
    public void SetName_EmptyName_ThrowsArgumentException(string invalidName)
    {
        var education = CreateValidEducation();

        Action act = () => education.SetName(invalidName);
        
        Assert.Throws<ArgumentException>(act);  
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void SetDescrition_EmptyDescription_ThrowsArgumentException(string invalidDescription)
    {
        var education = CreateValidEducation();
        Action act = () => education.SetDescription(invalidDescription);  
        Assert.Throws<ArgumentException>(act);
    }

    //Todo: Validate SetDate
}
                