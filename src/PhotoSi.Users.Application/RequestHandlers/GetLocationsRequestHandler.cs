using AutoMapper;
using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class GetLocationsRequestHandler : IRequestHandler<GetLocationsRequest, IEnumerable<LocationDto>>
{
    private readonly IMapper _mapper;
    private readonly ILocationsRepository _locationRepository;

    public GetLocationsRequestHandler(IMapper mapper, ILocationsRepository locationRepository)
    {
        _mapper = mapper;
        _locationRepository = locationRepository;
    }

    public async Task<IEnumerable<LocationDto>> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Location> locations = await _locationRepository.GetListAsync(request.UserId,
                                                                                 request.PageNum,
                                                                                 request.PageSize);

        return locations.Select(o => _mapper.Map<LocationDto>(o));
    }
}
