using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Blog : BaseDomainEntity
{
    public string Title { get; set; }
    public string Text { get; set; } = null!;
    public string Writer_Id { get; set; } = null!;
    public ApplicationUser User { get; set; }
    public ICollection<BlogComment>? Comments { get; set; }
}
