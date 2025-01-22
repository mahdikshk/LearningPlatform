using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Podcast : BaseDomainEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public string Path { get; set; }
    public string Author_Id { get; set; }
    public ApplicationUser Author { get; set; }
}
