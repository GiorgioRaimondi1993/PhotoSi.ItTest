using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Orders.Application.Requests;
public class UpdateOrderRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private set; }

    [JsonProperty("products")]
    public IEnumerable<Guid> Products { get; init; }

    [JsonProperty("locationId")]
    public Guid LocationId { get; init; }

    public void SetId(Guid id)
    {
        Id = id;
    }

}
