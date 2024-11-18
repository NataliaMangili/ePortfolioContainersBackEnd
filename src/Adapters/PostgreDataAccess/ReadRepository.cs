using System.Linq.Expressions;
using ePortfolio.Application.Ports;
using ePortfolio.Domain;
using Microsoft.EntityFrameworkCore;

namespace PostgreDataAccess;

public class ReadRepository<T,TContext>(TContext context) : IReadRepository<T> 
    where T : class,IEntity<Guid> 
    where TContext : DbContext  
{
    public IQueryable<T> GetPaging(int quanity, int currenctPage,Expression<Func<T, bool>> expre)
    {
        try
        {
            return context.Set<T>().Where(expre).Skip(quanity * currenctPage).Take(quanity);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}