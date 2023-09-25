// using CleanArch.Domain.Orders.ValueObjects;
// using CleanArch.Domain.Primitives;

// namespace CleanArch.Domain.Orders.Entities;

// public sealed class OrderCustomer : Entity<OrderCustomerId>
// {
//     public string Name { get; private set; }
//     public string Email { get; private set; }
//     public OrderCustomer()
//     {}
//     public OrderCustomer(OrderCustomerId id, string name, string email) : base(id)
//     {
//         this.Name = name;
//         this.Email = email;
//     }

//     public static OrderCustomer Create(string name, string email)
//     {
//         return new(
//             OrderCustomerId.CreateUnique(),
//             name,
//             email
//         );
//     }
// }