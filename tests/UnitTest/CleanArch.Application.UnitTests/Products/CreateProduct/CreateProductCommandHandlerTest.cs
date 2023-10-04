// using CleanArch.Application.Data.Interfaces;
// using CleanArch.Application.Products.Command.Create;
// using CleanArch.Application.UnitTests.Products.Extensions;
// using CleanArch.Application.UnitTests.Products.TestUtils;
// using FluentAssertions;
// using Moq;

// namespace CleanArch.Application.UnitTests.Products.CreateProduct;

// public class CreateProductCommandHandlerTest
// {
//      private readonly CreateProductCommandHandler _handler;
//     private readonly Mock<IUnitOfWork> _mockProductRespository;
//     public CreateProductCommandHandlerTest()
//     {   
//         _mockProductRespository = new Mock<IUnitOfWork>();
//         _handler = new CreateProductCommandHandler(_mockProductRespository.Object);
//     }

//     [Theory]
//     [MemberData(nameof(ValidCreateProductCommnads))]
//     public async void HandleCreateProductCommand_WhenMenuIsValid_ShouldCreateAndReturnProduct(CreateProductCommand createProductCommand)
//     {   
//         Arrange
//        var command = new CreateProductCommand("Huy", "string", "VND" , 1000);
//         var newGuid = new ProductId(Guid.NewGuid());
//         CreateProductCommand createProductCommand CreateProductCommand createProductCommand = CreateProductCommandUtils.CreateCommand();
//         Act
//         var result = await _handler.Handle(createProductCommand, default);
//         _mockUnitOfWork.Setup(x => x.Products.Add(results.Value));

//         Assert
//         var result = await _handler.Handle(command, default);

//         result.IsError.Should().BeFalse();
//         result.Value.validateCreatedFrom(createProductCommand);
//         _mockProductRespository.Verify(p => p.Products.Add(result.Value),Times.Once);

//     }

//     public static IEnumerable<object[]> ValidCreateProductCommnads()
//     {
//         var testparam = CreateProductCommandUtils.CreateCommand();
//         yield return new[] { CreateProductCommandUtils.CreateCommand() };
//     }
// }