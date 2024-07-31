using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;
internal class BlogCommentRepository : GenericRepository<BlogComment>, IBlogCommentRepository
{
    private readonly ApplicationDbContext _context;

    public BlogCommentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public IAsyncEnumerable<BlogComment> GetAllForBlogWithIdStreaming(int blogId)
    {
        return _context.BlogComments.Where(x=>x.Blog_Id == blogId).AsAsyncEnumerable();
    }

    public IAsyncEnumerable<BlogComment> GetAllForBlogWithIdStreamingWithDetails(int blogId)
    {
        return _context.BlogComments.Where(x=>x.Blog_Id == blogId).Include(x=>x.Blog).AsAsyncEnumerable();
    }
}
