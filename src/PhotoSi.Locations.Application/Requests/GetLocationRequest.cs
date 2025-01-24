using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Locations.Application.Requests;

public class GetLocationRequest : IRequest<LocationDto>
{
    public Guid Id { get; init; }
}

public class LocationDto
{
    [JsonProperty("id")]
    public Guid Id { get; private set; }

    [JsonProperty("userId")]
    public Guid UserId { get; private set; }


    [JsonProperty("city")]
    public string City { get; private set; }


    [JsonProperty("province")]
    public string Province { get; private set; }


    [JsonProperty("country")]
    public string Country { get; private set; }


    [JsonProperty("address")]
    public string Address { get; private set; }


    [JsonProperty("cap")]
    public string Cap { get; private set; }
}
