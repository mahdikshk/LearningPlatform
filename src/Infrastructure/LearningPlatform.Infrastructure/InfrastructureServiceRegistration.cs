﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Microsoft.ML;

namespace LearningPlatform.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        MLContext context = new();
        services.AddSingleton(context);
        services.AddRequiredPredictionEnginePoolServices();
        return services;
    }
}