using CleanArch.Application.Common.ProductResults;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Products.Common;
using CleanArch.Application.Products.Common.Exceptions;
using CleanArch.Domain.Products;
using MediatR;

namespace CleanArch.Application.Products.Command.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResult>
{
    private readonly IRespository<Product> _respository;
    private readonly IProductRespository _productRespository;

    public UpdateProductCommandHandler(IRespository<Product> respository, IProductRespository productRespository)
    {
        _respository = respository;
        _productRespository = productRespository;
    }

    public async Task<ProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var check_product = await _productRespository.GetByIdAsync(request.Id);

        if(check_product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }
        check_product.Update(request.Name, request.Sku);

         _respository.Update(check_product);
        await _respository.SaveChangeAsync(cancellationToken);

        return new ProductResult(check_product);
    }
}