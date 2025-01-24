using AutoMapper;
using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class GetLocationRequestHandler : IRequestHandler<GetLocationRequest, LocationDto>
{
    private readonly IMapper _mapper;
    private readonly ILocationsRepository _locationRepository;

    public GetLocationRequestHandler(IMapper mapper, ILocationsRepository locationRepository)
    {
        _mapper = mapper;
        _locationRepository = locationRepository;
    }

    public async Task<LocationDto> Handle(GetLocationRequest request, CancellationToken cancellationToken)
    {
        Location location = await _locationRepository.GetById(request.Id);

        return _mapper.Map<LocationDto>(location);
    }
}
