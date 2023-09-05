using CleanArch.Application.Common.Exceptions;
using CleanArch.Application.Common.Products;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Products;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Products.Command.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<ProductResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<ProductResult>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var check_product = await _unitOfWork.Products.GetByIDAsync(request.Id);

        if(check_product is null)
        {
            throw new NotFoundException(request.Id);
        }
        check_product.Update(request.Name, request.Sku, new Money(request.Currency, request.Amount));

         _unitOfWork.Products.Update(check_product);
        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return new ProductResult(check_product);
    }
}