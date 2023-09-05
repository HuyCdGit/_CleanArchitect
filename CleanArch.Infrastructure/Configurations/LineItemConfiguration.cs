using CleanArch.Domain.Customers;
using CleanArch.Domain.Orders;
using CleanArch.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configurations;

internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        ConfigureLineItemTable(builder);
    }

    public void ConfigureLineItemTable(EntityTypeBuilder<LineItem> builder)
    {
        builder.ToTable("LineItem");
        builder.HasKey(li => li.Id);
        
        builder.Property(li => li.Id).HasConversion(
            lineItemId => lineItemId.Value,
            value => new LineItemId(value)
        );
        
        builder.HasOne<Product>()
        .WithMany()
        .HasForeignKey(c => c.ProductId);

        builder.OwnsOne(li => li.Price);
    }
}   