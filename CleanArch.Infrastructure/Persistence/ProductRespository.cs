using Azure.Core;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence;
public class ProductRespository : IProductRespository
{
    private readonly ICleanArchDbContext _db;

    public ProductRespository(ICleanArchDbContext db)
    {
        _db = db;
    }

    public async Task<List<Product>> GetAllProduct()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(ProductId entity)
    {
        return  await _db.Products.FindAsync(entity);
    }
}