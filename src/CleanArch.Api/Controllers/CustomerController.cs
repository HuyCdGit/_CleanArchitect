// using CleanArch.Application.Customers.Command.Create;
// using CleanArch.Application.Customers.Command.Delete;
// using CleanArch.Application.Customers.Command.Update;
// using CleanArch.Application.Customers.Queries.CustomerById;
// using CleanArch.Application.Interfaces;
// using CleanArch.Domain.Customers;
// using CleanArch.Presentation.Common.Customers;
// using MapsterMapper;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace CleanArch.Api.Controllers;

// [Route("api")]
// public class CustomerController : ApiController
// {
//     private readonly ICleanArchDbContext _cleanArchDbContext;
//     private readonly ISender _sender;
//     private readonly IMapper _mapper;

//     public CustomerController(ICleanArchDbContext cleanArchDbContext, ISender sender, IMapper mapper)
//     {
//         _cleanArchDbContext = cleanArchDbContext;
//         _sender = sender;
//         _mapper = mapper;
//     }   

//     [HttpPost("AddCustomer")]
//     public async Task<IActionResult> AddCustomer([FromBody]CustomerRequest request)
//     {
//         var Command = new CreateCustomerCommand(request.Name,
//                                                request.Email);

//         var CustomerResult =  await _sender.Send(Command);
//         return CustomerResult.Match(
//             CustomerResult => Ok(_mapper.Map<CustomerResponse>(CustomerResult)),
//             errors => Problem(errors));
//     }

//     [HttpDelete("DeleteCustomer/{id:guid}")]
//     public async Task<IActionResult> DeleteCustomer(Guid id)
//     {
//         try
//         {
//             await _sender.Send(new DeleteCustomerCommand(new CustomerId(id)));
//             return NoContent();
//         }
//         catch (Exception e)
//         {
//            return NotFound(e.Message);
//         }
//     }

//     [HttpGet("GetCustomerById/{id:guid}")]
//     public async Task<IActionResult> GetCustomerById(Guid id)
//     {   
//         var customerResult = await _sender.Send(new QueryCustomer(new CustomerId(id)));

//         return Ok(customerResult);
//     }

//     [HttpGet("GetAllCustomer")]
//     public async Task<IActionResult> GetAllProduct()
//     {   
//         var result = await _cleanArchDbContext.Customers.ToListAsync();
//         return Ok(result);
//     }

//     [HttpPut("UpdateCustomer/{id:guid}")]
//     public async Task<IActionResult> UpdateProduct(Guid id ,CustomerRequest request)
//     {
//         var Command = new UpdateCustomerCommand(new CustomerId(id),
//                                                request.Name
//                                                ,request.Email);
                                               
//         var CustomerResult = await _sender.Send(Command);

//         return CustomerResult.Match(
//             CustomerResult => Ok(_mapper.Map<CustomerResponse>(CustomerResult)),
//             errors => Problem(errors));
//     }
// }