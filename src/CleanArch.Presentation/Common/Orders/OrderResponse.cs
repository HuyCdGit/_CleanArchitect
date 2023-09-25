using CleanArch.Presentation.Common.Customers;

namespace CleanArch.Presentation.Common.Orders;

public record OrderResponse(string Id, List<OrderCustomerResponse> OrderCustomerResponses);

public record OrderCustomerResponse(string Id, string Name, string Email);