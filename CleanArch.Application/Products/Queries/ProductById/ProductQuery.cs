using CleanArch.Application.Common.Products;
using CleanArch.Domain.Products;
using MediatR;

namespace CleanArch.Application.Products.Queries;

public record ProductQuery(ProductId Id) : IRequest<ProductResult>; 