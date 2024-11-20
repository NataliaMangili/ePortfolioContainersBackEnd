using System.Linq.Expressions;
using ePortfolio.Domain;

namespace ePortfolio.Application.Ports;

public interface IReadRepository<T,TId> where T : class,IEntity<TId> 
{
    IQueryable<T> GetPaging(int quanity, int currenctPage,Expression<Func<T, bool>> expre );
}