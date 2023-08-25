using System.Reflection;

namespace CleanArch.Presentation.Common.Products;

public record ProductResponse(ProductIdDTO id ,string Name, string Sku);