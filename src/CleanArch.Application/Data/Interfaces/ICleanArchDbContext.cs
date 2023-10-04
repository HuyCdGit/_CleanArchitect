using CleanArch.Domain.Menu;
using CleanArch.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.Interfaces;
public interface ICleanArchDbContext
{
    // DbSet<Customer> Customers {get;}
    // DbSet<Order> Orders {get;}
    DbSet<Product> Products {get;}
    // DbSet<LineItem> LineItems {get;}

    DbSet<Menu> Menus { get; }
    Task<int> SaveChangeAsync(CancellationToken cancellationToken);
}
