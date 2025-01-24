using PhotoSi.Orders.Application.Models;

namespace PhotoSi.Orders.Application.Repositories;

public interface IOrdersRepository
{
    Task<Order> GetById(Guid id);
    Task<IEnumerable<Order>> GetListAsync(Guid? userId = null,
                                          int pageNum = 0,
                                          int pageSize = 50);

    Task AddAsync(Order order);

    Task UpdateAsync(Order order);

    Task DeleteAsync(Order order);
}
