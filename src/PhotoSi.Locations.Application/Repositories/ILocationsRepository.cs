﻿using PhotoSi.Locations.Application.Models;

namespace PhotoSi.Locations.Application.Repositories;

public interface ILocationsRepository
{
    Task<Location> GetById(Guid id);
    Task<IEnumerable<Location>> GetListAsync(Guid? userId = null,
                                             int pageNum = 0,
                                             int pageSize = 50);

    Task AddAsync(Location location);

    Task UpdateAsync(Location location);

    Task DeleteAsync(Location location);
}
