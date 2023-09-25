// using CleanArch.Domain.Customers;
// using CleanArch.Domain.Orders;
// using CleanArch.Domain.Primitives;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace CleanArch.Infrastructure.Configurations;

// internal class OrderConfiguration : IEntityTypeConfiguration<Order>
// {
//     public void Configure(EntityTypeBuilder<Order> builder)
//     {
//         ConfigureOrderTable(builder);
//     }

//     public void ConfigureOrderTable(EntityTypeBuilder<Order> builder)
//     {
//         builder.ToTable("Order");
//         builder.HasKey(o => o.Id);

//         builder.Property(c => c.Id).HasConversion(
//             order => order.Value,
//             value => new OrderId(value)
//         );

//         builder.HasOne<Customer>()
//         .WithMany().HasForeignKey(o => o.CustomerId);

//         builder.HasMany(o => o.LineItems)
//         .WithOne()
//         .HasForeignKey(li => li.OrderId);
//     }
// }