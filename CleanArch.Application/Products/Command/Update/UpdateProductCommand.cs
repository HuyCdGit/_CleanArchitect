using CleanArch.Application.Common.Products;
using CleanArch.Domain.Products;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Products.Command.Update;

public record UpdateProductCommand(
                                    ProductId Id
                                    , string Name
                                    , Sku Sku
                                    , string Currency, decimal Amount): IRequest<ErrorOr<ProductResult>>; 