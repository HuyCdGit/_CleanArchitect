using CleanArch.Domain.Menu;
using ErrorOr;
using MediatR;

namespace  CleanArch.Application.Menus.Command.Create;
public record CreateMenuCommand(string HostId,
                                string Name,
                                string Description,
                                List<MenuSectionCommand> MenuSections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(string Name,
                          string Description,
                          List<MenuItemCommnad> MenuItems);

public record MenuItemCommnad(string Name,
                       string Description);
 