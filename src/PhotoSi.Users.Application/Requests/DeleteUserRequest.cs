using MediatR;

namespace PhotoSi.Users.Application.Requests;
public class DeleteUserRequest : IRequest
{
    public Guid Id { get; init; }
}
