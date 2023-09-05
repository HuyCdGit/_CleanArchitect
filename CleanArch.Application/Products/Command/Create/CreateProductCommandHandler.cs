using CleanArch.Application.Common.Products;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Common.Errors;
using CleanArch.Domain.Products;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Products.Command.Create
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<ProductResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ProductResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProductId = new ProductId(Guid.NewGuid());
            
            var check_product = await _unitOfWork.Products.GetByIDAsync(newProductId);

            if(check_product is not null)
            {
                return Errors.Product.DuplicateProduct;
            }
            //var newGuid = Guid.Parse("5E2AB0D2-F545-488A-A280-0CCE48F83027");

            var product = new Product(
                newProductId,
                request.Name,
                Sku.Create(request.Sku),
                new Money(request.Currency, request.Amount)
            );
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return new ProductResult(product);
        }
    }
}