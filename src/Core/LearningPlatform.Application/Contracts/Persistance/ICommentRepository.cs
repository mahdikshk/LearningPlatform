﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface ICommentRepository : IGenericRepository<Comment>
{
    public Task<IEnumerable<Comment>> GetAllWithDetailsAsync(CancellationToken token);
}
