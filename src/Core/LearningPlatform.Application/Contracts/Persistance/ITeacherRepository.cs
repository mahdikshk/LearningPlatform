using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<IEnumerable<Teacher>> GetAllWithDetailsAsync(CancellationToken token);
    Task<Teacher> GetTeacherWithDetailsAsync(int Id, CancellationToken token);
    Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name, CancellationToken token);
    Task<IEnumerable<Teacher>> GetTeachersByNameWithDetailsAsync(string name, CancellationToken token);

}
