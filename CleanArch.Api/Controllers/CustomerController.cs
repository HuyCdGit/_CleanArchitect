using CleanArch.Application.Customers.Queries.CustomerById;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Command.Create;
using CleanArch.Application.Products.Command.Delete;
using CleanArch.Application.Products.Command.Update;
using CleanArch.Domain.Customers;
using CleanArch.Domain.Products;
using CleanArch.Presentation.Common.Products;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Api.Controllers;

[Route("api")]
public class CustomerController : ApiController
{
    private readonly ICleanArchDbContext _cleanArchDbContext;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CustomerController(ICleanArchDbContext cleanArchDbContext, ISender sender, IMapper mapper)
    {
        _cleanArchDbContext = cleanArchDbContext;
        _sender = sender;
        _mapper = mapper;
    }   

    [HttpPost("AddCustomer")]
    public async Task<IActionResult> AddCustomer([FromBody]ProductRequest request)
    {
        var Command = new CreateProductCommand(request.Name,
                                               request.Sku,
                                               request.Currency,
                                               request.Amount);

        var prodResult =  await _sender.Send(Command);
        return prodResult.Match(
            prodResult => Ok(_mapper.Map<ProductResponse>(prodResult)),
            errors => Problem(errors));
    }

    [HttpDelete("DeleteCustomer/{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        try
        {
            await _sender.Send(new DeleteProductCommand(new ProductId(id)));
            return NoContent();
        }
        catch (Exception e)
        {
           return NotFound(e.Message);
        }
    }

    [HttpGet("GetCustomerById/{id:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {   
        var customerResult = await _sender.Send(new CustomerQuery(new CustomerId(id)));
        return customerResult.Match(
            customerResult => Ok(_mapper.Map<CustomerResponse>(customerResult)),
            errors => Problem(errors)
        ); 
    }

    [HttpGet("GetAllProduct")]
    public async Task<IActionResult> GetAllProduct()
    {   
        var result = await _cleanArchDbContext.Products.ToListAsync();
        return Ok(result);
    }

    [HttpPut("UpdateProduct/{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id ,ProductRequest request)
    {
        var Command = new UpdateProductCommand(new ProductId(id),
                                               request.Name,
                                               Sku.Create(request.Sku),
                                               request.Currency,
                                               request.Amount);
                                               
        var prodResult = await _sender.Send(Command);

        return prodResult.Match(
            prodResult => Ok(_mapper.Map<ProductResponse>(prodResult)),
            errors => Problem(errors));
    }
}