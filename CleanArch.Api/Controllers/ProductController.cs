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
public class ProductController : ApiController
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
        var Command = new CreateProductCommand(request.Name,
                                               request.Sku,
                                               request.Currency,
                                               request.Amount);

        var prodResult =  await _sender.Send(Command);
        return prodResult.Match(
            prodResult => Ok(_mapper.Map<ProductResponse>(prodResult)),
            errors => Problem(errors));
    }

    [HttpDelete("DeleteProduct/{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
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