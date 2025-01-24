using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoSi.Users.Application.Requests;
using System.Net.Mime;

namespace PhotoSi.Users.API.Controllers;

[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetLocation([FromRoute] Guid id)
    {
        GetLocationRequest request = new() { Id = id };

        LocationDto response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("")]
    public async Task<ActionResult> GetLocations([FromQuery] Guid? userId = null,
                                                 [FromQuery] int pageNum = 0,
                                                 [FromQuery] int pageSize = 50)
    {
        GetLocationsRequest request = new()
        {
            UserId = userId,
            PageNum = pageNum,
            PageSize = pageSize
        };

        IEnumerable<LocationDto> response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost("")]
    public async Task<ActionResult> CreateLocation([FromBody] CreateLocationRequest request)
    {
        Guid response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateLocation(
        [FromBody] UpdateLocationRequest request,
        [FromRoute] Guid id)
    {
        request.SetId(id);

        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteLocation([FromRoute] Guid id)
    {
        DeleteLocationRequest request = new() { Id = id };

        await _mediator.Send(request);

        return Ok();
    }
}
