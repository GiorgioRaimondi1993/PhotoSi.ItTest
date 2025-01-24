using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Users.Application.Requests;

public class CreateLocationRequest : IRequest<Guid>
{
    [JsonProperty("userId")]
    public Guid UserId { get; init; }

    [JsonProperty("city")]
    public string City { get; init; }

    [JsonProperty("province")]
    public string Province { get; init; }

    [JsonProperty("country")]
    public string Country { get; init; }

    [JsonProperty("address")]
    public string Address { get; init; }

    [JsonProperty("cap")]
    public string Cap { get; init; }
}
