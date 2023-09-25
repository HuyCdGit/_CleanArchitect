// using CleanArch.Application.Common.Exceptions;
// using CleanArch.Application.Customers.Command.Delete;
// using CleanArch.Application.Data.Interfaces;
// using MediatR;

// namespace CleanArch.Application.Products.Command.Delete;

// public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
// {
//     private readonly IUnitOfWork _unitOfWork;

//     public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
//     {
//         _unitOfWork = unitOfWork;
//     }

//     public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
//     {
//         var check_customer = await _unitOfWork.Customers.GetByIDAsync(request.Id);

//         if(check_customer is null)
//         {
//             throw new NotFoundException(request.Id);
//         }
//         _unitOfWork.Customers.Delete(check_customer);
//         await _unitOfWork.SaveChangeAsync(cancellationToken);
//     }
// }