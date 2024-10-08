﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;
internal class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    private readonly ApplicationDbContext _context;

    public BlogRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Blog>> GetAllWithDetailsAsync()
    {
        return await _context.Blogs.Include(x=>x.Comments).ToListAsync();
    }

    public async Task<Blog?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Blogs.Where(x => x.Id == id).Include(x => x.Comments).FirstOrDefaultAsync();
    }
}
