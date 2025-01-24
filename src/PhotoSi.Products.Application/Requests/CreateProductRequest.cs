using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Products.Application.Requests;

public class CreateProductRequest : IRequest<Guid>
{
    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("category")]
    public string Category { get; init; }
}
