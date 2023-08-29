using System.Reflection;
using CleanArch.Api.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArch.Api.Mapping;

public static class DependencyInjection 
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddSingleton<ProblemDetailsFactory, CleanArchDefaultProblemDetailsFactory>();

        return services;
    }
}