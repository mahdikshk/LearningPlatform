using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Application.Models.Identity;
using LearningPlatform.Identity.Models;
using LearningPlatform.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection RegisterIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options.UseSqlServer(configuration[""]);
        });
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}
