namespace CleanArch.Presentation.Common.Products;

public record ProductRequest(string Name, string Sku, string Currency, decimal Amount);