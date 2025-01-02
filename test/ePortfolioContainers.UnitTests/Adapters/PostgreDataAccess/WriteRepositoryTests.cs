using ePortfolio.Domain.Models.ProjectAggregate;
using ePortfolio.Infrastructure;

using PostgreDataAccess;
using Tests.Building.Blocks.Helpers;

namespace ePortfolioContainers.UnitTests.Adapters.PostgreDataAccess;

public class WriteRepositoryTests : InMemoryDatabaseHelper<EportfolioContext>
{
    
    //InsertAsync
    [Fact]
    public async Task InsertAsync_WhenSuccessful_ReturnsEntity()
    {
        var writeRepo = new WriteRepository<Tag, Guid, EportfolioContext>(InMemoryContext);
        Tag tag = new (".Net",Guid.NewGuid());

        var tagResult = await writeRepo.InsertAsync(tag);
        
        Assert.NotNull(tagResult);
        Assert.Equal(tag.Id, tagResult.Id);
        Assert.Equal(tag.Name, tagResult.Name); 

    }

    [Fact]
    public async Task InsertAsync_WhenEntityNull_ThrowsArgumentNullException()
    {
        var writeRepo = new WriteRepository<Tag, Guid, EportfolioContext>(InMemoryContext);
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await writeRepo.InsertAsync(null));
    }
    
   
    
    [Fact]
    public async Task UpdateAsync_WhenSuccessful_ReturnsEntity()
    {
        var writeRepo = new WriteRepository<Tag, Guid, EportfolioContext>(InMemoryContext);
        Tag tag = new (".Net", Guid.NewGuid());
        
        var tagResult = await writeRepo.InsertAsync(tag);
        tag.SetValidateName("Python");
        var tagUpdated= await writeRepo.UpdateAsync(tag,t=>t.Id ==tagResult.Id);
        
        Assert.NotNull(tagUpdated); 
        Assert.Equal(tag.Id, tagUpdated.Id);
        Assert.Equal(tag.Name, tagUpdated.Name);
        
    }

    [Fact]
    public async Task UpdateAsync_WhenEntityNotFound_ThrowsArgumentNullException()
    {
        var writeRepo = new WriteRepository<Tag, Guid, EportfolioContext>(InMemoryContext);
        Tag tag = new (".Net", Guid.NewGuid());
        
        var tagResult = await writeRepo.InsertAsync(tag);
        var task = async () => await writeRepo.UpdateAsync(tagResult,t=>false);
        
        await Assert.ThrowsAsync<ArgumentNullException>(task);        
    }
    
    
}