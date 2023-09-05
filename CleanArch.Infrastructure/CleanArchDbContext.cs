using System.Reflection;
using CleanArch.Application;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Customers;
using CleanArch.Domain.Orders;
using CleanArch.Domain.Products;
using CleanArch.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure;
public class CleanArchDbContext : IdentityDbContext<ApplicationUser> ,ICleanArchDbContext 
{
    public CleanArchDbContext(DbContextOptions<CleanArchDbContext> options) : base(options){}
    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Product> Products => Set<Product>();

   public DbSet<LineItem> LineItems => Set<LineItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

       base.OnModelCreating(builder);
    }

    public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync();
    }
}
