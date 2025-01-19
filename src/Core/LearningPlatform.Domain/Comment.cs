using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Comment : BaseDomainEntity
{
    public string Text { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
