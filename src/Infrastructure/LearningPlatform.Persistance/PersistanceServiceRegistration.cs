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
        services.AddDbContextPool<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("MainDB"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ICourseRepository, CourseRepository>();

        services.AddScoped<ICommentRepository, CommentRepository>();

        services.AddScoped<ITeacherRepository, TeacherRepository>();

        services.AddScoped<ICartRepository, CartRepository>();

        services.AddScoped<ICartItemRepository, CartItemRepository>();

        return services;
    }
}