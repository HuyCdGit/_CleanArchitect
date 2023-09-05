using System.Reflection;
using System.Security;

namespace CleanArch.Presentation.Common.Products;

public record ProductResponse(ProductIdDTO Id ,string Name, string Sku, string Currency, decimal Amount);
