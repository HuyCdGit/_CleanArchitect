// using System.Collections;
// using CleanArch.Application.Customers.Command.Create;
// using CleanArch.Application.Data.Interfaces;
// using CleanArch.Application.Orders.Command.Create;
// using CleanArch.Application.Orders.Command.Update;
// using CleanArch.Domain.Customers;
// using CleanArch.Domain.Orders;
// using CleanArch.Presentation.Common.Orders;
// using MapsterMapper;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// namespace CleanArch.Api.Controllers;

// [Route("api")]
// public class OrderController : ApiController
// {
//     private readonly IUnitOfWork _unitOfWork;
//     private readonly ISender _sender;
//     private readonly IMapper _mapper;

//     public OrderController(IUnitOfWork unitOfWork, ISender sender, IMapper mapper)
//     {
//         _unitOfWork = unitOfWork;
//         _sender = sender;
//         _mapper = mapper;

//     }

//     // [HttpPost("CreateOrder")]
//     // public async Task<IActionResult> CreateOrder(OrderRequest request, CancellationToken cancellationToken)
//     // {
//     //     var newGuid = Guid.Parse(request.OrderCustomers.Value.ToString());
//     //     var Command = new CreateOrderCommand(request.OrderCustomers, hostId);
//     //     var orderResult = await _sender.Send(Command);

//     //     return orderResult.Match(
//     //         orderResult => Ok(_mapper.Map<OrderResponse>(orderResult)),
//     //         errors => Problem(errors)
//     //     );
//     // }

//     [HttpPut("UpdateOrder/{id:guid}")]
//     public async Task<IActionResult> UpdateOrder(Guid id ,OrderRequest request, CancellationToken cancellationToken)
//     {
//         var parseCustomerId = Guid.Parse(request.CustomerId.Value.ToString());
//         var Command = new UpdateOrderCommand(new OrderId(id), new CustomerId(parseCustomerId));
//         var orderResult = await _sender.Send(Command);

//         return orderResult.Match(
//             orderResult => Ok(_mapper.Map<OrderResponse>(orderResult)),
//             errors => Problem(errors)
//         );
//     }
// }