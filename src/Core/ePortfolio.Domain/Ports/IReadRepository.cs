using System.Linq.Expressions;
using ePortfolio.Domain;

namespace ePortfolio.Application.Ports;

public interface IReadRepository<T> where T : class,IEntity<Guid> 
{
    IQueryable<T> GetAllPaging(int quanity, int currenctPage,Expression<Func<T, bool>> expre );
}