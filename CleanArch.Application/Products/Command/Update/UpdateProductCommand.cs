using CleanArch.Application.Common.ProductResults;
using CleanArch.Domain.Products;
using MediatR;

namespace CleanArch.Application.Products.Command.Update;

public record UpdateProductCommand(
                                    ProductId Id
                                    , string Name
                                    , Sku Sku): IRequest<ProductResult>; 