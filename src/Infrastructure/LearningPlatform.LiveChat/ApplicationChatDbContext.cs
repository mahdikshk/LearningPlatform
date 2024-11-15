using LearningPlatform.LiveChat.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.LiveChat;

public class ApplicationChatDbContext : DbContext
{
    public ApplicationChatDbContext(DbContextOptions<ApplicationChatDbContext> options) : base(options)
    {

    }
    public DbSet<Media> Medias { get; set; }
    public DbSet<MediaType> MediaTypes { get; set; }
    public DbSet<Message> Messages { get; set; }
}
