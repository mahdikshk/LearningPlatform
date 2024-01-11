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
        return services;
    }
}
