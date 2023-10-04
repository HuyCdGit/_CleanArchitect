using CleanArch.Domain.Primitives;

namespace CleanArch.Domain.Products;

public class Product : Entity<ProductId>
{
    public Product(ProductId id, string name, Sku sku, Money price) : this(id, name, sku)
    {
        Price = price;
    }
    private Product(ProductId id, string name, Sku sku)
        : base(id)
    {
        Name = name;
        Sku = sku;
    }
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; }
    public Sku Sku {get; private set;}
    // public void Create(ProductId id, string name, Sku sku, Money price)
    // {
        
    // }

    // public void Add(ProductId productId, Money price)
    // {
    //     var lineItem = new LineItem(
    //     new LineItemId(Guid.NewGuid())
    //     , Id
    //     , productId
    //     , price);

    //     _LineItems.Add(lineItem);
    // }
    public void Update(string name, Sku sku, Money price)
    {
        Name = name;
        Sku = sku;
        Price = price;
    }
}
