using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Users.Application.Requests;
public class UpdateLocationRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private set; }


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

    public void SetId(Guid id)
    {
        Id = id;
    }

}
