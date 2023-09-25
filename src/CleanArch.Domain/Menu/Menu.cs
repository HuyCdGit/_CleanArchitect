using System.ComponentModel;
using CleanArch.Domain.Common.Models;
using CleanArch.Domain.Host.ValueObjects;
using CleanArch.Domain.Menu.Entities;
using CleanArch.Domain.Menu.Envents;
using CleanArch.Domain.Menu.ValueObjects;

namespace CleanArch.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; }
    public DateTime CreateDateTime { get; private set; }
    public DateTime UpdateDateTime { get; private set; }

    private Menu(MenuId id,
                  string name,
                  string description,
                  HostId hostId,
                  List<MenuSection> sections
                ) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        //AverageRating = averageRating;
        CreateDateTime = DateTime.UtcNow;
        UpdateDateTime = DateTime.UtcNow;
        _sections = sections;
    }

    private Menu(MenuId id) : base(id)
    {
    }

    public static Menu Create(string name,
                              string description,
                              HostId hostId,
                              List<MenuSection>? sections)
    {
        var menu = new Menu(MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections ?? new());

        menu.AddDomainEvent(new MenuCreated(menu));
        return menu;
    }
}
