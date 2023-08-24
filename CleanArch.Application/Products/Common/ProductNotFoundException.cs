using CleanArch.Domain.Products;

namespace CleanArch.Application.Products.Common;

public sealed class ProductNotFoundException : Exception
{
    public ProductNotFoundException(ProductId id)
    : base($"The product with the ID = {id.Value} was not found'")
    {}
}