using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface ICourseRepository : IGenericRepository<Course>
{
    public Task<IEnumerable<Course>> GetAllCoursesWithDetail();
    public Task<Course> GetCourseByIdWithDetailsAsync(Guid id);
}
