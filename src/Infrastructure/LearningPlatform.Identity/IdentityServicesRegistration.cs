using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection RegisterIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<ApplicationIdentityDbContext>(options =>
        {
            options.UseNpgsql(configuration[""]);
        });
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();
        return services;
    }
}
