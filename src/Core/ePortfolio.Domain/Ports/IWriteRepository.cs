using ePortfolio.Domain.Models;
using System.Linq.Expressions;

namespace ePortfolio.Domain.Ports;
public interface IWriteRepository<T,TId,TContext> where T : class,IEntity<TId> 
{
    Task<T> InsertAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    Task<T> UpdateAsync(T entity,Expression<Func<T,bool>> expre);
    
    
}