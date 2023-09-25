// using CleanArch.Domain.Customers;
// using CleanArch.Domain.Primitives;
// using CleanArch.Domain.Products;

// namespace CleanArch.Domain.Orders;

// public class Order : Entity<OrderId>
// {
//     public Order(OrderId id, CustomerId customerId) : base(id)
//     {
//         this.CustomerId = customerId;
//     }

//     public Order(OrderId id) : base(id)
//     {}

//     public HashSet<LineItem> _LineItems => new();
//     public OrderId Id { get; set; }
//     public CustomerId CustomerId { get; set; }
//     // public HostId HostId {get;}
//     public IReadOnlyList<LineItem> LineItems => _LineItems.ToList();

//     public static Order Create(OrderId id ,CustomerId customerId)
//     {
//         var order = new Order(id, customerId)
//         {
//             Id = id,
//             CustomerId = customerId
//         };
//         return order;
//     }
//     public static Order Update(OrderId id ,CustomerId customerId)
//     {
//         var order = new Order(id, customerId)
//         {
//             Id = id,
//             CustomerId = customerId,
//         };
//         return order;
//     }
//     public void Add(ProductId productId, Money price)
//     {
//         var lineItem = new LineItem(
//         new LineItemId(Guid.NewGuid())
//         , Id
//         , productId
//         , price);

//         _LineItems.Add(lineItem);
//     }

// }
