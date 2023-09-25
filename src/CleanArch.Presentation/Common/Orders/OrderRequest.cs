using CleanArch.Presentation.Common.Customers;

namespace CleanArch.Presentation.Common.Orders;
public record OrderRequest(CustomerIdDTO CustomerId);

// public record OrderRequest(List<OrderCustomer> OrderCustomers);

// public record OrderCustomer(string name, string email);