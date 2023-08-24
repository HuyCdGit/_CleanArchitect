using CleanArch.Application.Common.ProductResults;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Products;
using MediatR;

namespace CleanArch.Application.Products.Command.Create
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResult>
    {
        private readonly IRespository<Product> _productRespository;

        public CreateProductCommandHandler(IRespository<Product> ProductRespository)
        {
            _productRespository = ProductRespository;
        }

        public async Task<ProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
               request.id,
                request.Name,
                //new Money(request.Currency, request.Amount),
                Sku.Create(request.Sku)
            );
            _productRespository.Add(product);
            await _productRespository.SaveChangeAsync(cancellationToken);
            return new ProductResult(product);
        }
    }
}