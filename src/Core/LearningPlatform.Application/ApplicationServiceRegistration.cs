using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
