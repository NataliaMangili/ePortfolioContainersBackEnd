using System.Linq.Expressions;
using ePortfolio.Domain;

namespace ePortfolio.Application.Ports;

public interface IWriteRepository<T, TContext> where T : class,IEntity<Guid> 
{
    Task<T> InsertAsync(T entity,Expression<Func<T,bool>> expre);
        
    Task<T> UpdateAsync(T entity,Expression<Func<T,bool>> expre);
}