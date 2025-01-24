using MediatR;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Application.Requests;

namespace PhotoSi.Users.Application.RequestHandlers;
public class DeleteLocationRequestHandler : IRequestHandler<DeleteLocationRequest>
{
    private readonly ILocationsRepository _locationRepository;

    public DeleteLocationRequestHandler(ILocationsRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task Handle(DeleteLocationRequest request, CancellationToken cancellationToken)
    {
        Location location = await _locationRepository.GetById(request.Id);

        if (location is null)
            return;

        await _locationRepository.DeleteAsync(location);
    }
}
