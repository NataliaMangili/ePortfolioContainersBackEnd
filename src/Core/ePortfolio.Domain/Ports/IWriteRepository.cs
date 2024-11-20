using System.Linq.Expressions;

namespace ePortfolio.Domain.Ports;

public interface IWriteRepository<T,TId> where T : class,IEntity<TId> 
{
    Task<T> InsertAsync(T entity);
        
    Task<T> UpdateAsync(T entity,Expression<Func<T,bool>> expre);
    
    
}