using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, Guid>
{
    private readonly IUsersRepository _usersRepository;

    public CreateUserRequestHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        User user = User.Create(request.FirstName,
                                request.LastName);

        await _usersRepository.AddAsync(user);

        return user.Id;
    }
}
