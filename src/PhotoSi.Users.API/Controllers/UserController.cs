using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoSi.Users.Application.Requests;
using System.Net.Mime;

namespace PhotoSi.Users.API.Controllers;

[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetUser([FromRoute] Guid id)
    {
        GetUserRequest request = new() { Id = id };

        UserDto response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("")]
    public async Task<ActionResult> GetUsers([FromQuery] int pageNum = 0,
                                             [FromQuery] int pageSize = 50)
    {
        GetUsersRequest request = new()
        {
            PageNum = pageNum,
            PageSize = pageSize
        };

        IEnumerable<UserDto> response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost("")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        Guid response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateUser(
        [FromBody] UpdateUserRequest request,
        [FromRoute] Guid id)
    {
        request.SetId(id);

        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid id)
    {
        DeleteUserRequest request = new() { Id = id };

        await _mediator.Send(request);

        return Ok();
    }
}
