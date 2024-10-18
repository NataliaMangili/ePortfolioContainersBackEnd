﻿using System.Linq.Expressions;
using ePortfolio.Application.Ports;
using ePortfolio.Domain;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace PostgreDataAccess;

public class WriteRepository<T,TContext>(TContext context) : IWriteRepository<T> 
    where T : Entity<Guid> 
    where TContext : DbContext  
{
    
    public async  Task<T> InsertAsync(T entity, Expression<Func<T, bool>> expre)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            await context.Set<T>().AddAsync(entity);
            
            if(await context.SaveChangesAsync() == 0 )
                throw new Exception("Entity could not be inserted");
            
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
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