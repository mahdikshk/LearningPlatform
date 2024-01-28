﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;
internal class TeacherRepository(ApplicationDbContext context) : GenericRepository<Teacher>(context), ITeacherRepository
{
    public async Task<IEnumerable<Teacher>> GetAllWithDetailsAsync(CancellationToken token)
    {
        return await context.Teachers
            .Include(t => t.Courses)
            .ToListAsync(cancellationToken: token);
    }

    public async Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name, CancellationToken token)
    {
        return await context.Teachers
            .Where(t => t.Name.ToLower().Contains(name.ToLower()))
            .ToArrayAsync(cancellationToken: token);
    }

    public async Task<IEnumerable<Teacher>> GetTeachersByNameWithDetailsAsync(string name, CancellationToken token)
    {
        return await context.Teachers
            .Where(t => t.Name.ToLower().Contains(name.ToLower()))
            .Include(t => t.Courses)
            .ToArrayAsync(cancellationToken: token);
    }

    public Task<Teacher?> GetTeacherWithDetailsAsync(Guid Id, CancellationToken token)
    {
        return context.Teachers
            .Include(t => t.Courses)
            .FirstOrDefaultAsync(t=>t.Id == Id,cancellationToken: token)!;
    }
}
