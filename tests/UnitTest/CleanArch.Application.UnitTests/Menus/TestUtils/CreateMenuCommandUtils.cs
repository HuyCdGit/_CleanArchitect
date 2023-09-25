using CleanArch.Application.Menus.Command.Create;
using CleanArch.Application.UnitTests.TestUtils.Constants;
namespace CleanArch.Application.UnitTests.Menus.TestUtils;

public class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(
        List<MenuSectionCommand>? sections = null
    ) =>
        new CreateMenuCommand(
          Constants.Host.Id.ToString()!,
          Constants.Menu.Name,
          Constants.Menu.Description,
          sections ?? CreateSectionCommand());

    public static List<MenuSectionCommand> CreateSectionCommand(
        int sectionCount = 1,
        List<MenuItemCommnad>? items = null
    ) =>
            Enumerable.Range(0, sectionCount)
                .Select(index => new MenuSectionCommand(
                    Constants.Menu.SectionNameFromIndex(index),
                    Constants.Menu.SectionDesriptionFromIndex(index),
                    items ?? CreateMenuItemCommand()))
                .ToList();

    public static List<MenuItemCommnad> CreateMenuItemCommand(int itemCount = 1) =>
            Enumerable.Range(0, itemCount)
                .Select(index => new MenuItemCommnad(
                    Constants.Menu.SectionNameFromIndex(index),
                    Constants.Menu.SectionDesriptionFromIndex(index)))
                .ToList();

}
