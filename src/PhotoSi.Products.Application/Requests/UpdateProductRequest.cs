using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Products.Application.Requests;
public class UpdateProductRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private set; }


    [JsonProperty("name")]
    public string Name { get; init; }


    [JsonProperty("category")]
    public string Category { get; init; }

    public void SetId(Guid id)
    {
        Id = id;
    }

}
