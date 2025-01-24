using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Users.Application.Requests;
public class UpdateUserRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private set; }


    [JsonProperty("firstName")]
    public string FirstName { get; init; }


    [JsonProperty("lastName")]
    public string LastName { get; init; }

    public void SetId(Guid id)
    {
        Id = id;
    }

}
