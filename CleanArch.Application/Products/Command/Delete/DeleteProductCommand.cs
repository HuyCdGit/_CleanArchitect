using CleanArch.Domain.Products;
using MediatR;

namespace CleanArch.Application.Products.Command.Delete;

public record DeleteProductCommand(ProductId Id) : IRequest;