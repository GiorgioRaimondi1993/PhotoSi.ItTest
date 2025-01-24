using MediatR;
using PhotoSi.Locations.Application.Models;
using PhotoSi.Locations.Application.Repositories;
using PhotoSi.Locations.Application.Requests;

namespace PhotoSi.Locations.Application.RequestHandlers;
public class CreateLocationRequestHandler : IRequestHandler<CreateLocationRequest, Guid>
{
    private readonly ILocationsRepository _locationRepository;

    public CreateLocationRequestHandler(ILocationsRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Guid> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        Location location = Location.Create(request.UserId,
                                            request.City,
                                            request.Province,
                                            request.Country,
                                            request.Address,
                                            request.Cap);

        await _locationRepository.AddAsync(location);

        return location.Id;
    }
}
