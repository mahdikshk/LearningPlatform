using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class BlogComment : BaseDomainEntity
{
    public string Text { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; }
    public int Blog_Id { get; set; }
    public Blog Blog { get; set; } = null!;
}
