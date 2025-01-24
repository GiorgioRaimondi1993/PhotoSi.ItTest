using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest>
{
    private readonly IUsersRepository _usersRepository;

    public UpdateUserRequestHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        User user = await _usersRepository.GetById(request.Id);

        if (user is null)
            throw new Exception("Invalid User");

        user.Update(request.FirstName,
                    request.LastName);

        await _usersRepository.UpdateAsync(user);
    }
}
