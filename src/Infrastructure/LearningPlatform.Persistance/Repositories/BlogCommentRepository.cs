using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Persistance.Repositories;
internal class BlogCommentRepository(ApplicationDbContext context) : GenericRepository<BlogComment>(context)
{
}
