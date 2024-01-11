using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public DbSet<Author> Authors { get; set; }
}
