// using System.ComponentModel.DataAnnotations;
// using CleanArch.Domain.Orders;
// using CleanArch.Domain.Primitives;

// namespace CleanArch.Domain.Customers;

// public class Customer : Entity<CustomerId>
// {
//     public Customer(CustomerId id, string name, string email) : base(id)
//     {
//         Id = id;
//         Name = name;
//         Email = email;
//     }
//     public HashSet<Order> _OrderCustomer => new();
//     public CustomerId Id {get; private set;}
//     public string Name { get; private set; }
//     public string Email { get; private set; }
//     public ICollection<Order> OrderCustomer => _OrderCustomer.ToList();


//     public void Update(string name, string email)
//     {
//         Name = name;
//         Email = email;
//     }
// }
