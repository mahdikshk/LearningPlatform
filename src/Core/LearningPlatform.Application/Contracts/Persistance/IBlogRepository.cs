using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface IBlogRepository : IGenericRepository<Blog>
{
    public Task<IEnumerable<Blog>> GetAllWithDetailsAsync();
}
