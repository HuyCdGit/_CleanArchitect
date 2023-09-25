// using CleanArch.Application.Common.Customers;
// using CleanArch.Application.Common.Exceptions;
// using CleanArch.Application.Data.Interfaces;
// using ErrorOr;
// using MediatR;

// namespace CleanArch.Application.Customers.Command.Update;

// public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<CustomerResult>>
// {
//     private readonly IUnitOfWork _unitOfWork;

//     public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
//     {
//         _unitOfWork = unitOfWork;
//     }

//     public async Task<ErrorOr<CustomerResult>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
//     {
//         var check_customer = await _unitOfWork.Customers.GetByIDAsync(request.Id);

//         if(check_customer is null)
//         {
//             throw new NotFoundException(request.Id);
//         }
//         check_customer.Update(request.Name, request.Email);

//          _unitOfWork.Customers.Update(check_customer);
//         await _unitOfWork.SaveChangeAsync(cancellationToken);

//         return new CustomerResult(check_customer);
//     }
// }