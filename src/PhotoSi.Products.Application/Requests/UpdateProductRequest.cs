using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Products.Application.Requests;
public class UpdateProductRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private set; }


    [JsonProperty("name")]
    public string Name { get; private set; }


    [JsonProperty("category")]
    public string Category { get; private set; }

    public void SetId(Guid id)
    {
        Id = id;
    }

}
