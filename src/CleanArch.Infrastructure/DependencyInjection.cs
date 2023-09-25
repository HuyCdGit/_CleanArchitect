using System.Diagnostics;
using CleanArch.Application;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Interfaces;
using CleanArch.Infrastructure.Interceptor;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        //services.AddDbContext<ICleanArchDbContext,CleanArchDbContext>(opt => opt.UseSqlServer(conn));
        services.AddDbContext<CleanArchDbContext>((sp, options) =>
        {
            options.UseSqlServer(conn);
        });
        services.AddScoped<ISaveChangesInterceptor,PublishDomainEventsInterceptor>();
        services.AddScoped<ICleanArchDbContext>(provider => provider.GetRequiredService<CleanArchDbContext>());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRespository<,>), typeof(Respository<,>));
        // services.AddScoped(typeof(IProductRespository), typeof(ProductRespository));
        
        return services;
    }
}