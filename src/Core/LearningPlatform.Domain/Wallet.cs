using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Wallet : BaseDomainEntity
{
    public int Balance { get; set; } = 0;
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
