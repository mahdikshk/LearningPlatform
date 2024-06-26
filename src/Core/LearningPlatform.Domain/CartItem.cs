using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class CartItem : BaseDomainEntity
{
    public int CartId { get; set; }
    public Cart Cart { get; set; }
    public int Course_Id { get; set; }
    public Course Course { get; set;}
}
