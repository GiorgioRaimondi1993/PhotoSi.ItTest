using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest>
{
    private readonly IUsersRepository _usersRepository;

    public DeleteUserRequestHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        User user = await _usersRepository.GetById(request.Id);

        if (user is null)
            return;

        await _usersRepository.DeleteAsync(user);
    }
}
