using MediatR;

namespace PhotoSi.Users.Application.Requests;
public class DeleteLocationRequest : IRequest
{
    public Guid Id { get; init; }
}
