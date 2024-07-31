using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface IBlogCommentRepository : IGenericRepository<BlogComment>
{
    public IAsyncEnumerable<BlogComment> GetAllForBlogWithIdStreaming(int blogId);
    public IAsyncEnumerable<BlogComment> GetAllForBlogWithIdStreamingWithDetails(int blogId);
}
