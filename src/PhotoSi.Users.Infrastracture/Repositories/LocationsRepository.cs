using Microsoft.EntityFrameworkCore;
using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Infrastracture.Sql;

namespace PhotoSi.Users.Infrastracture.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly UsersDbContext _context;

    public LocationsRepository(UsersDbContext context)
    {
        _context = context;
    }

    public async Task<Location> GetById(Guid id)
    {
        return await _context.Locations.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Location>> GetListAsync(Guid? userId = null, int pageNum = 0, int pageSize = 50)
    {
        return await _context.Locations
            .Where(o => userId == null || o.UserId == userId)
            .Skip(pageNum * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task AddAsync(Location location)
    {
        _context.Locations.Add(location);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Location location)
    {
        _context.Locations.Update(location);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Location location)
    {
        _context.Locations.Remove(location);

        await _context.SaveChangesAsync();
    }
}
