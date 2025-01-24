using MediatR;

namespace PhotoSi.Locations.Application.Requests;
public class DeleteLocationRequest : IRequest
{
    public Guid Id { get; init; }
}
