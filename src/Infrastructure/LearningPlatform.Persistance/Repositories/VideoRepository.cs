using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;

namespace LearningPlatform.Persistance.Repositories;
internal class VideoRepository : GenericRepository<Video>, IVideoRepository
{
    private readonly ApplicationDbContext _context;

    public VideoRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
