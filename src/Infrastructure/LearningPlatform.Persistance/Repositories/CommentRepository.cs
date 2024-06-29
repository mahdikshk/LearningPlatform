using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;
internal class CommentRepository(ApplicationDbContext context) : GenericRepository<Comment>(context), ICommentRepository
{
    public async Task<IEnumerable<Comment>> GetAllWithDetailsAsync(CancellationToken token)
    {
        return await context.Comments.Include(x => x.Course).ToListAsync();
    }
}
