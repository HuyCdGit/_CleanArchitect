using Castle.Components.DictionaryAdapter.Xml;
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
    private readonly Mock<IMenuRespository> _mockRespository;
    public CreateMenuCommandHandlerTest()
    {   
        _mockMenuRespository = new Mock<IUnitOfWork>();
        _handler = new CreateMenuCommandHandler(_mockMenuRespository.Object);
       
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
        _mockMenuRespository.Verify(m => m.AddAysnc(result.Value, default), Times.Once());
    }

    public static IEnumerable<object[]> ValidCreateMenuCommnads()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };

        yield  return new[] {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionCommand(sectionCount: 1)
            )
        };
        yield return new[] {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionCommand(
                    sectionCount: 1,
                    items: CreateMenuCommandUtils.CreateMenuItemCommand(itemCount: 1)     
                )
            )
        };

    }
}