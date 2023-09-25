// using CleanArch.Domain.Products;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace CleanArch.Infrastructure.Configurations;

// internal class ProductConfiguration : IEntityTypeConfiguration<Product>
// {
//     public void Configure(EntityTypeBuilder<Product> builder)
//     {
//         ConfigureProductTable(builder);
//     }

//     public void ConfigureProductTable(EntityTypeBuilder<Product> builder)
//     {
//         builder.ToTable("Product");
//         builder.HasKey(c => c.Id);

//         builder.Property(c => c.Id).HasConversion(
//             product => product.Value,
//             value => new ProductId(value)
//         );

//         builder.Property(c => c.Name).HasMaxLength(100);

//         builder.Property(c => c.Sku).HasConversion(
//             sku => sku.Value,
//             value => Sku.Create(value)! 
//         );

//         builder.OwnsOne(c => c.Price, prirceBuilder =>
//         {
//             prirceBuilder.Property(c => c.Currency).HasMaxLength(3);
            
//         });
//    }
// }