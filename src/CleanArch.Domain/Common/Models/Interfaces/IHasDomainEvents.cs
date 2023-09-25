using System.Collections.Generic;
namespace CleanArch.Domain.Common.Models.Interfaces;

public interface IHasDomainEvents 
{
    public IReadOnlyList<IDomainEvent> DomainEvents {get;}

    public void CleanDomainEvents();
}