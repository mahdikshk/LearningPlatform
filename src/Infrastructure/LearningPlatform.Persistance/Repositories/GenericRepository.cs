using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;
internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public Task AddBatchAsync(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        return Task.CompletedTask;
    }

    public Task AddBatchAsync(IAsyncEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetAsync(id);
        if (entity is not null)
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public Task DeleteBatchAsync(IEnumerable<T> entities)
    {
        _context.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public async Task DeleteBatchAsync(IAsyncEnumerable<T> entities)
    {
        await foreach (var entity in entities)
        {
            _context.Remove(entity);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToArrayAsync();
    }

    public async ValueTask<T?> GetAsync(Guid id) => await _context.Set<T>().FindAsync(id);

    public Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public Task UpdateBatchAsync(IEnumerable<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
        return Task.CompletedTask;
    }

    public async Task UpdateBatchAsync(IAsyncEnumerable<T> entities)
    {
        await foreach (var entity in entities)
        {
            _context.Update(entity);
        }
    }
}
