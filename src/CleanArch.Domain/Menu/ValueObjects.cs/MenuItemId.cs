using CleanArch.Domain.Common.Models;

namespace CleanArch.Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value) => new(value);
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
