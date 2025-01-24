using AutoMapper;
using MediatR;
using PhotoSi.Locations.Application.Models;
using PhotoSi.Locations.Application.Repositories;
using PhotoSi.Locations.Application.Requests;

namespace PhotoSi.Locations.Application.RequestHandlers;
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
