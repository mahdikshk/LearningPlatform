using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;
internal class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    private readonly ApplicationDbContext _context;
    public CourseRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesWithDetail(CancellationToken token)
    {
        return await _context.Courses
            .Include(x => x.Teacher)
            .Include(x => x.Description)
            .ToListAsync(token);
    }

    public async IAsyncEnumerable<Course> GetAllWithDetailsStreaming([EnumeratorCancellation]CancellationToken cancellationToken)
    {
        await foreach (var course in _context.Courses
            .Include(x => x.Teacher)
            .AsAsyncEnumerable())
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            yield return course;
        }
    }

    public async Task<Course> GetCourseByIdWithDetailsAsync(int id, CancellationToken token)
    {
        return await _context.Courses
            .Where(x => x.Id == id)
            .Include(x => x.Teacher)
            .FirstAsync(token);
    }

    public async Task<IEnumerable<Course>> SearchCoursesByNameAsync(string name, CancellationToken token)
    {
        return await _context.Courses
            .Where(x => x.Name.Contains(name))
            .ToListAsync(token);
    }
}
