using AutoMapper;
using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
{
    private readonly IMapper _mapper;
    private readonly IUsersRepository _usersRepository;

    public GetUserRequestHandler(IMapper mapper, IUsersRepository usersRepository)
    {
        _mapper = mapper;
        _usersRepository = usersRepository;
    }

    public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        User user = await _usersRepository.GetById(request.Id);

        return _mapper.Map<UserDto>(user);
    }
}
