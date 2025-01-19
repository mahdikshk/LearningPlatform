using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Cart : BaseDomainEntity
{
    public string User_Id { get; set; } = null!;
    public ApplicationUser User { get; set; }
    public bool IsPaymentWasSuccessfull { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
}
