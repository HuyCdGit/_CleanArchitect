using CleanArch.Domain.Menu.ValueObjects;
using CleanArch.Domain.Primitives;
namespace CleanArch.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set;}
    public string Description { get; private set;}
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly(); 
    private MenuSection(MenuSectionId id,
                       string name,
                       string description,
                       List<MenuItem> items) : base(id)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    private MenuSection(MenuSectionId id) : base(id)
    {
    }

    public static MenuSection Create(string name,
                                     string description,
                                     List<MenuItem>? items)
    {
        return new(MenuSectionId.CreateUnique(),
                   name,
                   description,
                   items ?? new());
    }
}