using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Course : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsFree { get; set; }
    public int? OriginalPrice { get; set; }
    public bool HasDiscount { get; set; }
    public int? DiscountPercentage { get; set; }
    public Guid Teacher_Id { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<CartItem>? CartItems { get; set;}
}