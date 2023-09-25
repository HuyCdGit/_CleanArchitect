using CleanArch.Domain.Menu.ValueObjects;

namespace CleanArch.Application.Common.Exceptions;

public sealed class NotFoundException : Exception
{
    // public NotFoundException(ProductId id)
    // : base($"The product with the ID = {id.Value} was not found'")
    // {}
    // public NotFoundException(CustomerId id) 
    // : base($"The customer with the ID = {id.Value} was not found'")
    // {}
    // public NotFoundException(OrderId id)
    // : base($"The order with the ID = {id.Value} was not found'")
    // {}

    public NotFoundException(MenuId id)
    : base($"The menu with the ID = {id.Value} was not found'")
    {}

}