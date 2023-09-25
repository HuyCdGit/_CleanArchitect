// using CleanArch.Application.Common.Exceptions;
// using CleanArch.Application.Common.Products;
// using CleanArch.Application.Data.Interfaces;
// using MediatR;

// namespace CleanArch.Application.Products.Queries.ProductById;
// internal class ProductQueryHandler : IRequestHandler<ProductQuery, ProductResult>
// {
//     private readonly IUnitOfWork _unitOfWork;

//     public ProductQueryHandler(IUnitOfWork unitOfWork)
//     {
//         _unitOfWork = unitOfWork;
//     }

//     public async Task<ProductResult> Handle(ProductQuery request, CancellationToken cancellationToken)
//     {
//         var check_product = await _unitOfWork.Products.GetByIDAsync(request.Id);

//         if (check_product is null)
//         {
//             throw new NotFoundException(request.Id);
//         }
//         // Guard.Against.Null(check_product, "Something were wrong");
//         return new ProductResult(check_product);
//     }
// }