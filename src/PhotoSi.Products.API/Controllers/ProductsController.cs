using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoSi.Products.Application.Requests;
using System.Net.Mime;

namespace PhotoSi.Products.API.Controllers;

[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetProduct([FromRoute] Guid id)
    {
        GetProductRequest request = new() { Id = id };

        ProductDto response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("")]
    public async Task<ActionResult> GetProducts([FromQuery] string category = null,
                                                [FromQuery] int pageNum = 0,
                                                [FromQuery] int pageSize = 50)
    {
        GetProductsRequest request = new()
        {
            Category = category,
            PageNum = pageNum,
            PageSize = pageSize
        };

        IEnumerable<ProductDto> response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost("")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        Guid response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateProduct(
        [FromBody] UpdateProductRequest request,
        [FromRoute] Guid id)
    {
        request.SetId(id);

        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
    {
        DeleteProductRequest request = new() { Id = id };

        await _mediator.Send(request);

        return Ok();
    }
}
