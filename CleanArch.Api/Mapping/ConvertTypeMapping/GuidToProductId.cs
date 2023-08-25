// using CleanArch.Application.Common.ProductResults;
// using CleanArch.Application.Interfaces;
// using CleanArch.Domain.Products;
// using CleanArch.Presentation.Common.Products;
// using JetBrains.Annotations;

// namespace CleanArch.Api.Mapping.ConvertTypeMapping;

// public class GuidToProductId : IValueResolver<ProductResult, ProductResponse, ProductId>
// {
//     public ProductId Resolve(ProductResult source, ProductResponse destination, ProductId destMember, ICleanArchDbContext context)
//     {
//         try
//        {
//             return new ProductId(destination.id);
//        }
//        catch
//        {
//             return default;
//        }
//     }
// }
