using MediatR;
using Newtonsoft.Json;

namespace PhotoSi.Users.Application.Requests;
public class UpdateUserRequest : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private set; }


    [JsonProperty("firstName")]
    public string FirstName { get; private set; }


    [JsonProperty("lastName")]
    public string LastName { get; private set; }

    public void SetId(Guid id)
    {
        Id = id;
    }

}
