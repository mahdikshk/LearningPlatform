using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediator();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
