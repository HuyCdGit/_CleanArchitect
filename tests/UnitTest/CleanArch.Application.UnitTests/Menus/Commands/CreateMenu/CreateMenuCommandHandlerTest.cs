using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Menus.Command.Create;
using CleanArch.Application.UnitTests.Menus.Extensions;
using CleanArch.Application.UnitTests.Menus.TestUtils;
using FluentAssertions;
using Moq;

namespace CleanArch.Application.UnitTests.Menus.Commands.CreateMenu;
public class CreateMenuCommandHandlerTest
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IUnitOfWork> _mockMenuRespository;
    public CreateMenuCommandHandlerTest()
    {
        _mockMenuRespository = new Mock<IUnitOfWork>();
        _handler = new CreateMenuCommandHandler(Mock.Of<IUnitOfWork>());

    }

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommnads))]
    public async void HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        //Act
        //Invoke the handler
        var result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.validateCreatedFrom(createMenuCommand);
        _mockMenuRespository.Verify(m => m.Menus.Add(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommnads()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand };

        yield  return new[] {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionCommand(sectionCount: 3)
            )
        };
        yield return new[] {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionCommand(
                    sectionCount: 3,
                    items: CreateMenuCommandUtils.CreateMenuItemCommand(itemCount: 3)     
                )
            )
        };

    }
}