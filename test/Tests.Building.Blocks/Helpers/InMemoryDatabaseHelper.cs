using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace Tests.Building.Blocks.Helpers;

public class InMemoryDatabaseHelper<TContext>
where TContext : DbContext   
{
    protected TContext InMemoryContext;

    protected InMemoryDatabaseHelper()
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