// using CleanArch.Domain.Customers;
// using CleanArch.Domain.Orders;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace CleanArch.Infrastructure.Configurations;

// internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
// {
//     public void Configure(EntityTypeBuilder<Customer> builder)
//     {
//         ConfigureCustomerTable(builder);
//     }

//     private void ConfigureCustomerTable(EntityTypeBuilder<Customer> builder)
//     {
//         builder.ToTable("Customer");

//         builder.HasKey(c => c.Id);

//         builder.Property(c => c.Id).HasConversion(
//          customer => customer.Value,    
//          value => new CustomerId(value));

//         builder.Property(c => c.Name).HasMaxLength(100);

//         builder.Property(c => c.Email).HasMaxLength(255);

//         builder.HasIndex(c => c.Email).IsUnique();
//     }

// }