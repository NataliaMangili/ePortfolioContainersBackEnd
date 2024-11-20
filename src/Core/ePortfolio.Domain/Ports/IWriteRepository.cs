using System.Linq.Expressions;
using ePortfolio.Domain;

namespace ePortfolio.Application.Ports;

public interface IWriteRepository<T,TId> where T : class,IEntity<TId> 
{
    Task<T> InsertAsync(T entity,Expression<Func<T,bool>> expre);
        
    Task<T> UpdateAsync(T entity,Expression<Func<T,bool>> expre);
}