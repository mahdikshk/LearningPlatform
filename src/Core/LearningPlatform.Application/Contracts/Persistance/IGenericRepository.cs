using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();
    public ValueTask<T> GetAsync(Guid id);
    public Task DeleteAsync(Guid id);
    public Task UpdateAsync(T entity);
    public Task AddAsync(T entity);
    public Task AddBatchAsync(IEnumerable<T> entities);
    public Task AddBatchAsync(IAsyncEnumerable<T> entities);
    public Task UpdateBatchAsync(IEnumerable<T> entities);
    public Task UpdateBatchAsync(IAsyncEnumerable<T> entities);

    public Task DeleteBatchAsync(IEnumerable<T> entities);
    public Task DeleteBatchAsync(IAsyncEnumerable<T> entities);

}
