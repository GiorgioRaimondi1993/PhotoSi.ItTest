using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoSi.Orders.Application.Requests;
using System.Net.Mime;

namespace PhotoSi.Orders.API.Controllers;

[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetOrder([FromRoute] Guid id)
    {
        GetOrderRequest request = new() { Id = id };

        OrderDto response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("")]
    public async Task<ActionResult> GetOrders([FromQuery] Guid? userId = null,
                                              [FromQuery] int pageNum = 0,
                                              [FromQuery] int pageSize = 50)
    {
        GetOrdersRequest request = new()
        {
            UserId = userId,
            PageNum = pageNum,
            PageSize = pageSize
        };

        IEnumerable<OrderDto> response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost("")]
    public async Task<ActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        Guid response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateOrder(
        [FromBody] UpdateOrderRequest request,
        [FromRoute] Guid id)
    {
        request.SetId(id);

        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteOrder([FromRoute] Guid id)
    {
        DeleteOrderRequest request = new() { OrderId = id };

        await _mediator.Send(request);

        return Ok();
    }
}
