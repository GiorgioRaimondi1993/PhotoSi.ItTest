using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Users.Application.Requests;
public class UpdateLocationRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private set; }


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

    public void SetId(Guid id)
    {
        Id = id;
    }

}
