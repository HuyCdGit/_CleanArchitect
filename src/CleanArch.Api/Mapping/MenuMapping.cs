using CleanArch.Application.Menus.Command.Create;
using CleanArch.Domain.Menu;
using CleanArch.Presentation.Common.Menus;
using Mapster;

using MenuSection = CleanArch.Domain.Menu.Entities.MenuSection;
using MenuItem = CleanArch.Domain.Menu.Entities.MenuItem;

namespace CleanArch.Api.Mapping;

public sealed class MenuMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating);

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
            
        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
