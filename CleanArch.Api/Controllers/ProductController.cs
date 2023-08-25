using CleanArch.Application.Common.ProductResults;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Command.Create;
using CleanArch.Application.Products.Command.Delete;
using CleanArch.Application.Products.Command.Update;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Products;
using CleanArch.Presentation.Common.Products;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Api.Controllers;

[Route("api")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICleanArchDbContext _cleanArchDbContext;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ProductController(ICleanArchDbContext cleanArchDbContext, ISender sender, IMapper mapper)
    {
        _cleanArchDbContext = cleanArchDbContext;
        _sender = sender;
        _mapper = mapper;
    }   

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody]ProductRequest request)
    {
        var command = new CreateProductCommand(new ProductId(Guid.NewGuid()),request.Name, request.Sku);
        var result =  await _sender.Send(command); 
        return Ok(_mapper.Map<ProductResponse>(result));
    }

    [HttpDelete("DeleteProduct/{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _sender.Send(new DeleteProductCommand(new ProductId(id)));
        return NoContent();
    }

    [HttpGet("GetProductById/{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {   
        var result = await _sender.Send(new ProductQuery(new ProductId(id)));
        return Ok(result);
    }

    [HttpGet("GetAllProduct")]
    public async Task<IActionResult> GetAllProduct()
    {   
        var result = await _cleanArchDbContext.Products.ToListAsync();
        return Ok(result);
    }

    [HttpPut("UpdateProduct/{id:guid}")]
    public async Task<ActionResult<ProductResult>> UpdateProduct(Guid id ,ProductRequest request)
    {
        var command = new UpdateProductCommand(new ProductId(id) ,request.Name, Sku.Create(request.Sku));
        var result = await _sender.Send(command);
        return Ok(result);
    }
}