using System.Reflection.Metadata;
using CleanArch.Domain.Customers;
using CleanArch.Domain.Products;

namespace CleanArch.Domain.Orders;

public class Order
{
    private Order()
    { }
    //public HashSet<LineItem> _LineItems => new();
    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }

    //public IReadOnlyList<LineItem> LineItems => _LineItems.ToList();

    public static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId
        };
        return order;
    }
    // public void Add(ProductId productId, Money price)
    // {
    //     var lineItem = new LineItem(
    //     new LineItemId(Guid.NewGuid())
    //     , Id
    //     , productId
    //     , price);

    //     _LineItems.Add(lineItem);
    // }

}
