﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Cart : BaseDomainEntity
{
    public bool IsPaymentWasSuccessfull { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
}
