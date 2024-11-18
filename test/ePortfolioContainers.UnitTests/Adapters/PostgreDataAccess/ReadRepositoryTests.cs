using System.Linq.Expressions;
using ePortfolio.Domain.Models.ProjectAggregate;
using ePortfolio.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using PostgreDataAccess;

namespace ePortfolioContainers.UnitTests.Adapters.PostgreDataAccess;

public class ReadRepositoryTests
{
    [Fact]
    public void GetPaging_EmptyCollection_ReturnsEmptyCollection()
    {
        var context = new Mock<EportfolioContext>();
        IQueryable<Tag> data = Enumerable.Empty<Tag>().AsQueryable();  
        
        var mockSet = new Mock<DbSet<Tag>>();
        mockSet.As<IQueryable<Tag>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Tag>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Tag>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Tag>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
        
        context.Setup(s => s.Set<Tag>()).Returns(mockSet.Object);
        var readRepo = new ReadRepository<Tag,EportfolioContext>(context.Object);

        var list = readRepo.GetPaging(10, 0, x => x.Inclusion > DateTime.Now);
        Assert.Empty(list);
    }
}