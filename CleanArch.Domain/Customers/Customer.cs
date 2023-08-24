using System.ComponentModel.DataAnnotations;

namespace CleanArch.Domain.Customers;

public class Customer
{
    public CustomerId Id {get; private set;}
    public string Name { get; private set; }
    public string Email { get; private set; }
}
