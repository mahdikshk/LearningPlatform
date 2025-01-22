using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Ticket : BaseDomainEntity
{
    public string Text { get; set; }
    public string Author_Id { get; set; }
    public ApplicationUser Author { get; set; }
}
