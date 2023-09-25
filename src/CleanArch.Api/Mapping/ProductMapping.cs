// using CleanArch.Application.Common.Customers;
// using CleanArch.Application.Common.Products;
// using CleanArch.Presentation.Common.Products;
// using Mapster;

// namespace CleanArch.Api.Mapping;

// public sealed class ProductMapping : IRegister
// {
//     public void Register(TypeAdapterConfig config)
//     {
//         config.NewConfig<ProductResult, ProductResponse>()
//         .Map(d => d, e => e.product)
//         .Map(d => d.Sku, e => e.product.Sku.Value.ToString())
//         .Map(d => d.Currency, e => e.product.Price.Currency)
//         .Map(d => d.Amount, e => e.product.Price.Amount);
//     }
// }