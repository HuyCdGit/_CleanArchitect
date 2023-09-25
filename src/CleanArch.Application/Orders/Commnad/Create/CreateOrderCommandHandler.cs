// using CleanArch.Application.Common.Exceptions;
// using CleanArch.Application.Common.Orders;
// using CleanArch.Application.Data.Interfaces;
// using CleanArch.Domain.Common.Errors;
// using CleanArch.Domain.Customers;
// using CleanArch.Domain.Orders;
// using ErrorOr;
// using MediatR;

// namespace CleanArch.Application.Orders.Command.Create;

// internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ErrorOr<OrderResult>>
// {
//     private readonly IUnitOfWork _unitOfWork;

//     public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
//     {
//         _unitOfWork = unitOfWork;
//     }

//     public async Task<ErrorOr<OrderResult>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
//     {
//         //Create Order
//         var newOrder = new OrderId(Guid.NewGuid());
//         var check_Order = await _unitOfWork.Orders.GetByIDAsync(newOrder);

//         if(check_Order is not null) return Errors.Order.Duplicate;
        
//         var newCustomerId = new CustomerId(request.);
//         var check_customer = await _unitOfWork.Customers.GetByIDAsync(newCustomerId);
//         if(check_customer is null)
//         {
//             throw new NotFoundException(new CustomerId(request.CustomerId.Value));
//         }

//         var order = Order.Create(newOrder, newCustomerId);

//         _unitOfWork.Orders.Add(order);
//         await _unitOfWork.SaveChangeAsync(cancellationToken);

//         return new OrderResult(order);
//     }
// }