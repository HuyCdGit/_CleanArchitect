using CleanArch.Application.Common.ProductResults;
using CleanArch.Domain.Products;
using MediatR;

namespace CleanArch.Application.Products.Command.Create;

public record CreateProductCommand(
                                  ProductId id
                                , string Name
                                , string Sku
                                //, string Currency, decimal Amount
                                ) : IRequest<ProductResult>;