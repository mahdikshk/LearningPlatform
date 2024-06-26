using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Topic : BaseDomainEntity
{
    public required string Name { get; set; }
    public int Course_Id { get; set; }
    public Course Course { get; set; } = null!;
    public ICollection<Video>? Videos { get; set; }
}
