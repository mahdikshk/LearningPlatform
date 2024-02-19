﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
internal interface IWalletRepository : IGenericRepository<Wallet>
{
}
