using System.Diagnostics;
using CleanArch.Application;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Interfaces;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArch.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services
    , IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("CleanArchDb");
        services.AddDbContext<CleanArchDbContext>(opt => opt.UseSqlServer(conn));

        services.AddScoped<ICleanArchDbContext>(provider => provider.GetRequiredService<CleanArchDbContext>());

        services.AddScoped(typeof(IRespository<>), typeof(Respository<>));
        services.AddScoped(typeof(IProductRespository), typeof(ProductRespository));
        
        return services;
    }
}