using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Products.Common;
using CleanArch.Domain.Products;
using MediatR;

namespace CleanArch.Application.Products.Command.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IRespository<Product> _respository;
    private readonly IProductRespository _productRespository;

    public DeleteProductCommandHandler(IRespository<Product> respository, IProductRespository productRespository)
    {
        _respository = respository;
        _productRespository = productRespository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var check_product = await _productRespository.GetByIdAsync(request.Id);

        if(check_product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }
        _respository.Delete(check_product);

        await _respository.SaveChangeAsync(cancellationToken);
    }
}