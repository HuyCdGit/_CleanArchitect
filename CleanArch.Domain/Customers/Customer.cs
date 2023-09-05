using System.ComponentModel.DataAnnotations;
using CleanArch.Domain.Primitives;

namespace CleanArch.Domain.Customers;

public class Customer : Entity<CustomerId>
{
    public Customer(CustomerId id, string name, string email) : base(id)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public CustomerId Id {get; private set;}
    public string Name { get; private set; }
    public string Email { get; private set; }
}
