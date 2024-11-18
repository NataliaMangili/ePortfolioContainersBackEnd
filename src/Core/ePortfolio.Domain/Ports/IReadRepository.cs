using System.Linq.Expressions;
using ePortfolio.Domain;

namespace ePortfolio.Application.Ports;

public interface IReadRepository<T> where T : class,IEntity<Guid> 
{
    IQueryable<T> GetPaging(int quanity, int currenctPage,Expression<Func<T, bool>> expre );
}