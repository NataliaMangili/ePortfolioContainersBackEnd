using System.Linq.Expressions;
using ePortfolio.Domain.Models.ProjectAggregate;
using ePortfolio.Infrastructure;
using ePortfolioContainers.UnitTests.Adapters.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using PostgreDataAccess;

namespace ePortfolioContainers.UnitTests.Adapters.PostgreDataAccess;

public class ReadRepositoryTests : AdapterTestBase<EportfolioContext>
{
    [Fact]
    public void GetPaging_WhenNoColletion_ReturnsEmptyCollection()
    {
        var readRepo = new ReadRepository<Tag,EportfolioContext>(InMemoryContext);
        
        var list = readRepo.GetPaging(10, 0,t=>false);
        Assert.Empty(list);
    }

    [Fact]
    public void GetPaging_WhenColletion_ReturnsCollection()
    {
        Tag testTag = new("TestName", Guid.NewGuid());
        
        InMemoryContext.Set<Tag>().Add(testTag);
        InMemoryContext.SaveChanges();
        
        var readRepo = new ReadRepository<Tag,EportfolioContext>(InMemoryContext);
        
        var list = readRepo.GetPaging(10, 0,t=>t.Name == "TestName");
        Assert.Single(list);
        Assert.Equal(testTag.Name,list.First().Name);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(-1, -1)]
    public void GetPaging_WhenInvalidParams_ThrowsArgumentException(int quanity, int currenctPage)
    {
        var readRepo = new ReadRepository<Tag,EportfolioContext>(InMemoryContext);
        
        Action  act = () => readRepo.GetPaging(quanity, currenctPage, t => true);
        
        Assert.Throws<ArgumentException>(act);
        
    }
        
        
    
}