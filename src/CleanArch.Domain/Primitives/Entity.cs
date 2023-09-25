using CleanArch.Domain.Common.Models;
using CleanArch.Domain.Common.Models.Interfaces;

namespace CleanArch.Domain.Primitives;

// public abstract class Entity<TEntityId> : IEquatable<Entity<TEntityId>>
 //where TEntityId : notnull
 public abstract class  Entity<TEntityId> : IHasDomainEvents where TEntityId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public TEntityId Id { get; protected set; }
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    protected Entity(TEntityId id)
    {
        Id = id;
    }
    public override bool Equals(object? obj)
    {
        return obj is Entity<TEntityId> entity && Id.Equals(entity.Id);
    }

    public bool Equals(Entity<TEntityId>? other)
    {
        return Equals((object?) other);
    }

    public static bool operator ==(Entity<TEntityId> left,
                                   Entity<TEntityId> right) => Equals(left, right);
    public static bool operator !=(Entity<TEntityId> left,
                                 Entity<TEntityId> right) => Equals(left, right);
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void CleanDomainEvents()
    {
        _domainEvents.Clear();
    }
}