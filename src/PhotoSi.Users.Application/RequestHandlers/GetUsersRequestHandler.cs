using AutoMapper;
using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, IEnumerable<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUsersRepository _usersRepository;

    public GetUsersRequestHandler(IMapper mapper, IUsersRepository usersRepository)
    {
        _mapper = mapper;
        _usersRepository = usersRepository;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<User> user = await _usersRepository.GetListAsync(request.PageNum,
                                                                     request.PageSize);

        return user.Select(o => _mapper.Map<UserDto>(o));
    }
}
