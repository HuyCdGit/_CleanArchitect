using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Host.ValueObjects;
using CleanArch.Domain.Menu;
using CleanArch.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Menus.Command.Create;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMenuCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        //await Task.CompletedTask;
        var menu = Menu.Create(
            hostId : HostId.Create(Guid.NewGuid()),
            name: request.Name,
            description: request.Description,
            sections: request.MenuSections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.MenuItems.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                )))));

        await _unitOfWork.AddAysnc(menu, cancellationToken); 
        return menu;
    }
}
