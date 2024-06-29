using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;

namespace LearningPlatform.Persistance.Repositories;
internal class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    private readonly ApplicationDbContext _context;

    public BlogRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
