using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.UnitTest.Scenario;

namespace PhotoSi.Users.UnitTest.Services;
public class MockUsersRepository : IUsersRepository
{
    private UserScenario _scenario;
    public MockUsersRepository(UserScenario scenario)
    {
        _scenario = scenario;
    }

    public Task AddAsync(User user)
    {
        _scenario.Users.TryAdd(user.Id, user);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(User user)
    {
        _scenario.Users.Remove(user.Id);

        return Task.CompletedTask;
    }

    public Task<User> GetById(Guid id)
    {
        User user = _scenario.Users.Values.SingleOrDefault(o => o.Id == id);
        return Task.FromResult(user);
    }

    public Task<IEnumerable<User>> GetListAsync(int pageNum = 0, int pageSize = 50)
    {
        IEnumerable<User> users = _scenario.Users.Values
            .Skip(pageNum * pageSize).Take(pageSize).ToList();

        return Task.FromResult(users);
    }

    public Task UpdateAsync(User user)
    {
        _scenario.Users[user.Id] = user;

        return Task.CompletedTask;
    }
}
