using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
    public ValueTask<T> GetAsync(Guid id,CancellationToken token);
    public Task DeleteAsync(Guid id, CancellationToken token);
    public Task UpdateAsync(T entity, CancellationToken token);
    public Task AddAsync(T entity, CancellationToken token);
    public Task AddBatchAsync(IEnumerable<T> entities, CancellationToken token);
    public Task AddBatchAsync(IAsyncEnumerable<T> entities, CancellationToken token);
    public Task UpdateBatchAsync(IEnumerable<T> entities, CancellationToken token);
    public Task UpdateBatchAsync(IAsyncEnumerable<T> entities, CancellationToken token);

    public Task DeleteBatchAsync(IEnumerable<T> entities, CancellationToken token);
    public Task DeleteBatchAsync(IAsyncEnumerable<T> entities, CancellationToken token);
}
