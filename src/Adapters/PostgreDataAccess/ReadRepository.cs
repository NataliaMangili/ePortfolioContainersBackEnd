using System.Linq.Expressions;
using ePortfolio.Application.Ports;
using ePortfolio.Domain;
using Microsoft.EntityFrameworkCore;

namespace PostgreDataAccess;

public class ReadRepository<T,TId,TContext>(TContext context) : IReadRepository<T,TId> 
    where T : class,IEntity<TId> 
    where TContext : DbContext  
      
{
    public IQueryable<T> GetPaging(int quanity, int currenctPage,Expression<Func<T, bool>> expre)
    {
        try
        {
            if (quanity <= 0 || currenctPage <= 0)
            {
                throw new ArgumentException("quanity must be greater than 0");  
            }
            
            return context.Set<T>().Where(expre).Skip(quanity * currenctPage).Take(quanity);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}