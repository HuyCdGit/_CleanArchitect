using CleanArch.Application.Common.ProductResults;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Products.Common.Exceptions;
using MediatR;

namespace CleanArch.Application.Products.Queries.ProductById;
internal class ProductQueryHandler : IRequestHandler<ProductQuery, ProductResult>
{
    private readonly IProductRespository _productRespository;

    public ProductQueryHandler(IProductRespository productRespository)
    {
        _productRespository = productRespository;
    }

    public async Task<ProductResult> Handle(ProductQuery request, CancellationToken cancellationToken)
    {
        var check_product = await _productRespository.GetByIdAsync(request.Id);

        if (check_product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }
        // Guard.Against.Null(check_product, "Something were wrong");
        return new ProductResult(check_product);
    }
}