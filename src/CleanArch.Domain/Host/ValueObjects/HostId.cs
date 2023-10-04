using CleanArch.Domain.Common.Models;

namespace CleanArch.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        this.Value = value;
    }

    private HostId(string value) 
    {
    }
    public static HostId CreateUnique() => new(Guid.NewGuid());

    public static HostId Create(Guid value) => new(value);
    public static HostId Create(string hostId) => new HostId(hostId);
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
