// using CleanArch.Domain.Primitives;
// using CleanArch.Domain.Products;

// namespace CleanArch.Domain.Orders;

// public class LineItem : Entity<LineItemId>
// {
//     public LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price): this(id, orderId, productId)
//     {
//         Price = price;
//     }
//     private LineItem(LineItemId id, OrderId orderId, ProductId productId) : base(id)
//     {
//         Id = id;
//         OrderId = orderId;
//         ProductId = productId;
//     }

//     public LineItemId Id { get; private set; }
//     public OrderId OrderId { get; private set; }
//     public ProductId ProductId { get; private set; }
//     public Money Price { get; private set; }
// }
