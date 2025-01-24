using MediatR;

namespace PhotoSi.Users.Application.Requests;
public class GetUsersRequest : IRequest<IEnumerable<UserDto>>
{
    public int PageNum { get; init; }

    public int PageSize { get; init; }
}
