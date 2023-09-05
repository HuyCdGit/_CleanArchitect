using CleanArch.Application.Common.Customers;
using CleanArch.Application.Common.Exceptions;
using CleanArch.Application.Data.Interfaces;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Customers.Queries.CustomerById;
internal class CustomerQueryHandler : IRequestHandler<CustomerQuery, ErrorOr<CustomerResult>>
{
    private readonly ICustomerRespository _customerRespository;

    public CustomerQueryHandler(ICustomerRespository customerRespository)
    {
        _customerRespository = customerRespository;
    }

    public async Task<ErrorOr<CustomerResult>> Handle(CustomerQuery request, CancellationToken cancellationToken)
    {
        var check_Customer = await _customerRespository.GetByIDAsync(request.Id);

        if (check_Customer is null)
        {
            throw new NotFoundException(request.Id);
        }
        // Guard.Against.Null(check_product, "Something were wrong");
        return new CustomerResult(check_Customer);
    }
}