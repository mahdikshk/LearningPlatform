using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Domain.Common;
public abstract class BaseDomainEntity
{
    public Guid Id { get; set; }
    public DateTime DateOfCreate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime LastModifyDate { get; set;}
    public string LastModifiedBy { get; set;} = null!;
}
