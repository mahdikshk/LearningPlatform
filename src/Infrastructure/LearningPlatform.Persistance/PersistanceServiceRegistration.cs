using System.Reflection;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.Models.Identity;
using LearningPlatform.Persistance.Models;
using LearningPlatform.Persistance.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LearningPlatform.Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddDbContextPool<ApplicationDbContext>(options=>
        {
            options.UseSqlServer(configuration.GetConnectionString("MainDB"));
            options.LogTo((str) =>
            {

            },LogLevel.Error);
        });
        services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
        {
            opt.Lockout.AllowedForNewUsers = false;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

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

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}