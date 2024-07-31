using System.Reflection;
using FluentValidation;
using LearningPlatform.Application.DTO;
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
        services.AddValidatorsFromAssemblyContaining<BaseDTO>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
