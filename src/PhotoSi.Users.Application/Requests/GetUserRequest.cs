using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Users.Application.Requests;

public class GetUserRequest : IRequest<UserDto>
{
    public Guid Id { get; init; }
}

public class UserDto
{
    [JsonProperty("id")]
    public Guid Id { get; private set; }

    [JsonProperty("firstName")]
    public string FirstName { get; private set; }


    [JsonProperty("lastName")]
    public string LastName { get; private set; }
}
