using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
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
