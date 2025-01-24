using PhotoSi.Users.Application.Models;

namespace PhotoSi.Users.Application.Repositories;

public interface IUsersRepository
{
    Task<User> GetById(Guid id);

    Task<IEnumerable<User>> GetListAsync(int pageNum = 0,
                                         int pageSize = 50);

    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(User user);
}
