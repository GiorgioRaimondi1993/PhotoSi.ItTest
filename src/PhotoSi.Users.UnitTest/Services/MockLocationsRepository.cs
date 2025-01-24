using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.UnitTest.Scenario;

namespace PhotoSi.Locations.UnitTest.Services;
public class MockLocationsRepository : ILocationsRepository
{
    private UserScenario _scenario;
    public MockLocationsRepository(UserScenario scenario)
    {
        _scenario = scenario;
    }

    public Task AddAsync(Location location)
    {
        _scenario.Locations.TryAdd(location.Id, location);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Location location)
    {
        _scenario.Locations.Remove(location.Id);

        return Task.CompletedTask;
    }

    public Task<Location> GetById(Guid id)
    {
        Location location = _scenario.Locations.Values.SingleOrDefault(o => o.Id == id);
        return Task.FromResult(location);
    }

    public Task<IEnumerable<Location>> GetListAsync(Guid? userId = null, int pageNum = 0, int pageSize = 50)
    {
        IEnumerable<Location> locations = _scenario.Locations.Values
            .Where(l => userId is null || l.UserId == userId)
            .Skip(pageNum * pageSize).Take(pageSize).ToList();

        return Task.FromResult(locations);
    }

    public Task UpdateAsync(Location location)
    {
        _scenario.Locations[location.Id] = location;

        return Task.CompletedTask;
    }
}
