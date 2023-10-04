using CleanArch.Application.Products.Command.Create;
using CleanArch.Domain.Products;
using FluentAssertions;
namespace CleanArch.Application.UnitTests.Products.Extensions;

public static class ProductExtensions
{
    public static void validateCreatedFrom(this Product product, CreateProductCommand command)
    {
        product.Name.Should().Be(command.Name);
        product.Id.Should().NotBeNull();
        product.Sku.Should().NotBeNull();
        product.Price.Should().NotBeNull();
    }
}