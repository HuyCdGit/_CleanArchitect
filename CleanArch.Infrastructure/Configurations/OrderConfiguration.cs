using CleanArch.Domain.Customers;
using CleanArch.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(c => c.Id).HasConversion(
            order => order.Value,
            value => new OrderId(value)
        );

        builder.HasOne<Customer>()
        .WithMany()
        .HasForeignKey(c => c.CustomerId)
        .IsRequired();

        // builder.HasMany(o => o.LineItems)
        // .WithOne()
        // .HasForeignKey(li => li.OrderId);
    }
}