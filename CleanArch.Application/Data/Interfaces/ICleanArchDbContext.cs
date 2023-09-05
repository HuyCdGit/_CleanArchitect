using CleanArch.Domain.Customers;
using CleanArch.Domain.Orders;
using CleanArch.Domain.Products;
using Microsoft.EntityFrameworkCore;
namespace CleanArch.Application.Interfaces;
public interface ICleanArchDbContext
{
    DbSet<Customer> Customers {get;}
    DbSet<Order> Orders {get;}
    DbSet<Product> Products {get;}
    DbSet<LineItem> LineItems {get;}
    Task<int> SaveChangeAsync(CancellationToken cancellationToken);
}
