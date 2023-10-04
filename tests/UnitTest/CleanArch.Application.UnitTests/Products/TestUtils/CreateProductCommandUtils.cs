using CleanArch.Application.Products.Command.Create;
using CleanArch.Application.UnitTests.TestUtils.Constants;
namespace CleanArch.Application.UnitTests.Products.TestUtils;

public class CreateProductCommandUtils
{
    public static CreateProductCommand CreateCommand() =>
        new CreateProductCommand(
            Constants.Product.Name,
            Constants.Product.Sku,
            Constants.Product.Currency,
            Constants.Product.Amount
        );
}

// var newProduct = new Product(
        //     id: newGuid,
        //     name: command.Name,
        //     sku: Sku.Create(command.Sku),
        //     price : new Money(command.Currency, command.Amount)
        // );