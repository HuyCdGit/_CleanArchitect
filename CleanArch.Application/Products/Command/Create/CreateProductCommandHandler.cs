using CleanArch.Application.Common.ProductResults;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Common.Errors;
using CleanArch.Domain.Products;
using ErrorOr;
using JetBrains.Annotations;
using MediatR;

namespace CleanArch.Application.Products.Command.Create
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<ProductResult>>
    {
        private readonly IRespository<Product> _respository;
        private readonly IProductRespository _productRespository;

        public CreateProductCommandHandler(IRespository<Product> respository, IProductRespository productRespository)
        {
            _respository = respository;
            _productRespository = productRespository;
        }

        public async Task<ErrorOr<ProductResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if(_productRespository.GetByIdAsync(request.id) is not null)
            {
                return Errors.Product.DuplicateProduct;
            }
            var newGuid = Guid.Parse("5E2AB0D2-F545-488A-A280-0CCE48F83027");
            
            var product = new Product(
               new ProductId(newGuid),
                request.Name,
                //new Money(request.Currency, request.Amount),
                Sku.Create(request.Sku)
            );
            _respository.Add(product);
            await _respository.SaveChangeAsync(cancellationToken);
            return new ProductResult(product);
        }
    }
}