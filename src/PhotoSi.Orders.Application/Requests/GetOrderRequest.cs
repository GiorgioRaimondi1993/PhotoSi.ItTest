using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Orders.Application.Requests;

public class GetOrderRequest : IRequest<OrderDto>
{
    public Guid Id { get; init; }
}

public class OrderDto
{
    [JsonProperty("id")]
    public Guid Id { get; private set; }

    [JsonProperty("userId")]
    public Guid UserId { get; private set; }

    [JsonProperty("locationId")]
    public Guid LocationId { get; private set; }

    [JsonProperty("products")]
    public IEnumerable<Guid> Products { get; private set; }
}
