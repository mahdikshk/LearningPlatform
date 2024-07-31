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

    public async Task<T> AddAsync(T entity, CancellationToken token)
    {
        await _context.Set<T>().AddAsync(entity, token);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task AddBatchAsync(IEnumerable<T> entities, CancellationToken token)
    {
        await _context.AddRangeAsync(entities: entities, cancellationToken: token);
    }

    public async ValueTask AddBatchAsync(IAsyncEnumerable<T> entities, CancellationToken token)
    {
        await foreach (var i in entities)
        {
            if (token.IsCancellationRequested)
                return;
            await _context.Set<T>().AddAsync(i, cancellationToken: token);

        }
    }

    public async Task DeleteAsync(int id, CancellationToken token)
    {
        var entity = await GetAsync(id);
        if (entity is not null)
        {
            if (token.IsCancellationRequested)
                return;
            _context.Set<T>().Remove(entity);
        }
    }

    public Task DeleteBatchAsync(IEnumerable<T> entities, CancellationToken token)
    {
        _context.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public async Task DeleteBatchAsync(IAsyncEnumerable<T> entities, CancellationToken token)
    {
        await foreach (var entity in entities)
        {
            if (token.IsCancellationRequested)
                return;
            _context.Remove(entity);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token)
    {
        return await _context.Set<T>().ToArrayAsync(token);
    }

    public IAsyncEnumerable<T> GetAllAsyncStreaming(CancellationToken token)
    {
        return _context.Set<T>().AsAsyncEnumerable();
    }

    public async ValueTask<T?> GetAsync(int id) =>
        await _context.Set<T>().FindAsync(id);

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
            if (token.IsCancellationRequested)
                return;
            _context.Update(entity);
        }
    }
}