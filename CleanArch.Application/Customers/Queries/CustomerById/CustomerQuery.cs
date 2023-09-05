using CleanArch.Application.Common.Customers;
using CleanArch.Domain.Customers;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Customers.Queries.CustomerById;

public record CustomerQuery(CustomerId Id) : IRequest<ErrorOr<CustomerResult>>; 