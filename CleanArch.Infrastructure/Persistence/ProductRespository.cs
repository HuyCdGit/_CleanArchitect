using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence;
internal sealed class ProductRespository : Respository<Product, ProductId>, IProductRespository
{
    private readonly CleanArchDbContext _dbContext;
    public ProductRespository(CleanArchDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAllProduct()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIDAsync(ProductId id)
    {
        return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
    }

    //Có thể Override phương thức (Virtual)
    // public async Task<Product?> GetByIdAsync(ProductId entity)
    // {
    //     return  await _dbContext.Products.FindAsync(entity);
    // }
}