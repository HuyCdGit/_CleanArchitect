using CleanArch.Api.Mapping;
using CleanArch.Presentation;
namespace CleanArch.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMapping();
        services.AddPresentation();
        services.AddControllers();
        return services;
    }
}