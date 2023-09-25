using System.Reflection;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Common.Models.Interfaces;
using CleanArch.Domain.Menu;
using CleanArch.Infrastructure.Identity;
using CleanArch.Infrastructure.Interceptor;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure;
public class CleanArchDbContext : IdentityDbContext<ApplicationUser>, ICleanArchDbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public CleanArchDbContext(PublishDomainEventsInterceptor publishDomainEventsInterceptor)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public CleanArchDbContext(DbContextOptions<CleanArchDbContext> options) : base(options) { }
    //     public DbSet<Customer> Customers => Set<Customer>();

    //     public DbSet<Order> Orders => Set<Order>();

    //     public DbSet<Product> Products => Set<Product>();

    //    public DbSet<LineItem> LineItems => Set<LineItem>();

    public DbSet<Menu> Menus { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder
        .Ignore<List<IDomainEvent>>()
        .ApplyConfigurationsFromAssembly(typeof(CleanArchDbContext).Assembly);
        base.OnModelCreating(builder);
    }

    public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
