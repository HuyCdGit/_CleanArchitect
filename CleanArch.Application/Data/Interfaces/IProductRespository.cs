using CleanArch.Domain.Products;

namespace CleanArch.Application.Data.Interfaces;

public interface IProductRespository
{
     Task<Product> GetByIdAsync(ProductId entity);

     Task<List<Product>> GetAllProduct();
}