using CleanArch.Application.Common.Customers;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Customers.Command.Create;

public record CreateCustomerCommand(
                                string Name
                                , string Email
                                ) : IRequest<ErrorOr<CustomerResult>>;