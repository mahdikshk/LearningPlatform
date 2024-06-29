using System.Reflection;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("MainDB"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IBlogRepository, BlogRepository>();

        services.AddScoped<IBlogCommentRepository, BlogCommentRepository>();

        services.AddScoped<ICartRepository, CartRepository>();

        services.AddScoped<ICartItemRepository, CartItemRepository>();

        services.AddScoped<ICourseRepository, CourseRepository>();

        services.AddScoped<ICommentRepository, CommentRepository>();

        services.AddScoped<IPodcastRepository, PodcastRepository>();

        services.AddScoped<ITeacherRepository, TeacherRepository>();

        services.AddScoped<ITicketRepository, TicketRepository>();

        services.AddScoped<ITopicRepository, TopicRepository>();

        services.AddScoped<IVideoRepository, VideoRepository>();

        services.AddScoped<IWalletRepository, WalletRepository>();

        return services;
    }
}