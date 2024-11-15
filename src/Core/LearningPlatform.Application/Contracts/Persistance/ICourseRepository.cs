using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface ICourseRepository : IGenericRepository<Course>
{
    public IAsyncEnumerable<Course> GetAllWithDetailsStreaming(CancellationToken cancellationToken);
    public Task<IEnumerable<Course>> GetAllCoursesWithDetail(CancellationToken token);
    public Task<Course> GetCourseByIdWithDetailsAsync(int id, CancellationToken token);
    public Task<IEnumerable<Course>> SearchCoursesByNameAsync(string name, CancellationToken token);

}
