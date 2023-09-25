// using CleanArch.Application.Common.Exceptions;
// using CleanArch.Application.Common.Orders;
// using CleanArch.Application.Data.Interfaces;
// using CleanArch.Application.Interfaces;
// using CleanArch.Domain.Customers;
// using CleanArch.Domain.Orders;
// using ErrorOr;
// using MediatR;
// using Microsoft.EntityFrameworkCore;

// namespace CleanArch.Application.Orders.Command.Update;

// internal sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ErrorOr<OrderResult>>
// {
//     private readonly ICleanArchDbContext _dbContext;
//     private readonly IUnitOfWork _unitOfWork;

//     public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, ICleanArchDbContext dbContext)
//     {
//         _dbContext = dbContext;
//         _unitOfWork = unitOfWork;
//     }

//     public async Task<ErrorOr<OrderResult>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
//     {
    
//         var check_Order = await _unitOfWork.Orders.GetByIDAsync(request.Id);
//         if(check_Order is not null)
//             throw new NotFoundException(request.Id);

//         var check_customer = _dbContext.Customers.Where(c => c.Id == request.CustomerId).ToListAsync();
//         if(check_customer is null)
//             throw new NotFoundException(new CustomerId(request.CustomerId.Value));

//         check_Order.CustomerId = request.CustomerId;
//         check_Order.Id = request.Id;

//         _unitOfWork.Orders.Update(check_Order);
//         await _unitOfWork.SaveChangeAsync(cancellationToken);

//         return new OrderResult(null);
//     }
// }