using CleanArch.Domain.Primitives;

namespace CleanArch.Domain.Common.Models;

public abstract class AggregateRoot<TEntityId> : Entity<TEntityId>
where TEntityId : ValueObject
{
    protected AggregateRoot(TEntityId id) : base(id)
    {
        
    }
}