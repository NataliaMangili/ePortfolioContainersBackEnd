using ePortfolio.Domain;
using ePortfolio.Infrastructure;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ePortfolioContainers.UnitTests.Adapters.Helpers;

public class AdapterTestBase<TContext> 
    where TContext : DbContext   
{
    protected TContext InMemoryContext;

    protected AdapterTestBase()
    {
        InMemoryContext = GenerateInMemoryContext();
    }

    private TContext GenerateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<TContext>()
            .UseInMemoryDatabase("x"+Guid.NewGuid().ToString()).Options;
        
        var context = (TContext)Activator.CreateInstance(typeof(TContext), options)!;
        
        ArgumentNullException.ThrowIfNull(context);
        
        return context;
    }
}