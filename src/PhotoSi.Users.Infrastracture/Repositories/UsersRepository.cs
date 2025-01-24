using Microsoft.EntityFrameworkCore;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Infrastracture.Sql;

namespace PhotoSi.Users.Infrastracture.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UsersDbContext _context;

    public UsersRepository(UsersDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetById(Guid id)
    {
        return await _context.Users.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<User>> GetListAsync(int pageNum = 0, int pageSize = 50)
    {
        return await _context.Users
            .Skip(pageNum * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}
