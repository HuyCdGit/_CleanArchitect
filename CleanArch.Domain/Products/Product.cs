using System.Runtime.CompilerServices;

namespace CleanArch.Domain.Products;

public class Product{
    public Product(ProductId id, string name, Sku sku)//Money price,
    {
        Id = id;
        Name = name;
        //Price = price;
        Sku = sku;
    }

    public ProductId Id {get; private set;}
    public string Name { get; private set; } = string.Empty;
   // public Money? Price { get; set; }
    public Sku Sku {get; private set;}
    
    public void Update(string name, Sku sku)
    {
        Name = name;
        Sku = sku;
    }
}
