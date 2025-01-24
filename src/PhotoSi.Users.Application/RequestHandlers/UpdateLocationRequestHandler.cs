using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class UpdateLocationRequestHandler : IRequestHandler<UpdateLocationRequest>
{
    private readonly ILocationsRepository _locationRepository;

    public UpdateLocationRequestHandler(ILocationsRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task Handle(UpdateLocationRequest request, CancellationToken cancellationToken)
    {
        Location location = await _locationRepository.GetById(request.Id);

        if (location is null)
            throw new Exception("Invalid Location");

        location.Update(request.City,
                        request.Province,
                        request.Country,
                        request.Address,
                        request.Cap);

        await _locationRepository.UpdateAsync(location);
    }
}
