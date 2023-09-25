// using CleanArch.Application.Common.Customers;
// using CleanArch.Application.Common.Exceptions;
// using CleanArch.Application.Data.Interfaces;
// using MediatR;

// namespace CleanArch.Application.Customers.Queries.CustomerById;

// internal class QueryCustomerHandler : IRequestHandler<QueryCustomer, CustomerResult>
// {
//     private readonly IUnitOfWork _unitOfWork;

//     public QueryCustomerHandler(IUnitOfWork unitOfWork)
//     {
//         _unitOfWork = unitOfWork;
//     }

//     public async Task<CustomerResult> Handle(QueryCustomer request, CancellationToken cancellationToken)
//     {
//         var check_customer = await _unitOfWork.Customers.GetByIDAsync(request.Id);

//         if (check_customer is null)
//         {
//             throw new NotFoundException(request.Id);
//         }

//         return new CustomerResult(check_customer);
//     }
// }