using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Orders.Application.Requests;

public class CreateOrderRequest : IRequest<Guid>
{
    [JsonProperty("userId")]
    public Guid UserId { get; init; }

    [JsonProperty("products")]
    public IEnumerable<Guid> Products { get; init; }

    [JsonProperty("locationId")]
    public Guid LocationId { get; init; }
}
