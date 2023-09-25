using System;
using CleanArch.Application.Menus.Command.Create;
using CleanArch.Domain.Menu;
using CleanArch.Domain.Menu.Entities;
using FluentAssertions;
namespace CleanArch.Application.UnitTests.Menus.Extensions;

public static class MenuExtensions
{
    public static void validateCreatedFrom(this Menu menu, CreateMenuCommand command)
    {
        menu.Name.Should().Be(command.Name);
        menu.Name.Should().Be(command.Description);
        menu.Sections.Should().HaveSameCount(command.MenuSections);
        menu.Sections.Zip(command.MenuSections).ToList().ForEach(pair => ValidateSection(pair.First, pair.Second));
    }

    static void ValidateSection(MenuSection section, MenuSectionCommand command)
    {
        section.Id.Should().NotBeNull();
        section.Name.Should().Be(command.Name);
        section.Description.Should().Be(command.Description);
        section.Items.Should().HaveSameCount(command.MenuItems);
        section.Items.Zip(command.MenuItems).ToList().ForEach(pair => ValidateItems(pair.First, pair.Second));
    }

    static void ValidateItems(MenuItem menuItem, MenuItemCommnad commnad)
    {
        menuItem.Id.Should().NotBeNull();
        menuItem.Name.Should().Be(commnad.Name);
        menuItem.Description.Should().Be(commnad.Description);
    }
}