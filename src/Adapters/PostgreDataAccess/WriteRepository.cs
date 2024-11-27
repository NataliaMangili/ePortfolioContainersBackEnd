using System.Linq.Expressions;
using ePortfolio.Application.Ports;
using ePortfolio.Domain;
using ePortfolio.Domain.Models;
using ePortfolio.Domain.Ports;
using Microsoft.EntityFrameworkCore;
using ArgumentNullException = System.ArgumentNullException;
using Exception = System.Exception;

namespace PostgreDataAccess;


public class WriteRepository<T,TId,TContext>(TContext context) : IWriteRepository<T,TId,TContext> 
    where T : Entity<TId> 

    where TContext : DbContext  
{
    
    public async  Task<T> InsertAsync(T entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            await context.Set<T>().AddAsync(entity);
            
            if(await context.SaveChangesAsync() == 0 )
                throw new Exception("Entity could not be inserted");
            
            return await Task.FromResult(entity);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex);  
            throw;   
        }
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entities);

            await context.Set<T>().AddRangeAsync(entities);

            if (await context.SaveChangesAsync() == 0)
                throw new Exception("Entities could not be inserted");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> expre)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            var oldEntity = await context.Set<T>().FirstOrDefaultAsync(expre);

            ArgumentNullException.ThrowIfNull(oldEntity);
            
            oldEntity = entity;

            context.Update(oldEntity);
            
            if(await context.SaveChangesAsync() == 0 )
                throw new Exception("Entity could not be updated");
            
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);  
            throw;   
        }
    }

   
}