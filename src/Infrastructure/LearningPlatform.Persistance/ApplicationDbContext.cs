using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LearningPlatform.Persistance;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogComment> BlogComments { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Podcast> Podcasts { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
