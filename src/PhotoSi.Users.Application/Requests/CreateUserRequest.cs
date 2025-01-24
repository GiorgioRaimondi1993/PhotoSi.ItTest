using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Users.Application.Requests;

public class CreateUserRequest : IRequest<Guid>
{
    [JsonProperty("firstName")]
    public string FirstName { get; init; }

    [JsonProperty("lastName")]
    public string LastName { get; init; }
}
