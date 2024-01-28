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

    public async Task AddAsync(T entity, CancellationToken token)
    {
        await _context.Set<T>().AddAsync(entity, token);
    }

    public Task AddBatchAsync(IEnumerable<T> entities, CancellationToken token)
    {
        _context.Set<T>().AddRange(entities);
        return Task.CompletedTask;
    }

    public async Task AddBatchAsync(IAsyncEnumerable<T> entities, CancellationToken token)
    {
        await foreach (var i in entities)
        {
            await _context.Set<T>().AddAsync(i, cancellationToken: token);
        }
    }

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var entity = await GetAsync(id, token);
        if (entity is not null)
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public Task DeleteBatchAsync(IEnumerable<T> entities, CancellationToken token)
    {
        _context.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public async Task DeleteBatchAsync(IAsyncEnumerable<T> entities,CancellationToken token)
    {
        await foreach (var entity in entities)
        {
            _context.Remove(entity);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token)
    {
        return await _context.Set<T>().ToArrayAsync(token);
    }

    public async ValueTask<T> GetAsync(Guid id, CancellationToken token) =>
        await _context.Set<T>().FindAsync(new object[] { id }, token);

    public Task UpdateAsync(T entity, CancellationToken token)
    {
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public Task UpdateBatchAsync(IEnumerable<T> entities, CancellationToken token)
    {
        _context.Set<T>().UpdateRange(entities);
        return Task.CompletedTask;
    }

    public async Task UpdateBatchAsync(IAsyncEnumerable<T> entities, CancellationToken token)
    {
        await foreach (var entity in entities)
        {
            _context.Update(entity);
        }
    }
}
