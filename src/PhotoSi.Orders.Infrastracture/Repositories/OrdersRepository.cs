using Microsoft.EntityFrameworkCore;
using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Infrastracture.Sql;

namespace PhotoSi.Orders.Infrastracture.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly OrdersDbContext _context;

    public OrdersRepository(OrdersDbContext context)
    {
        _context = context;
    }

    public async Task<Order> GetById(Guid id)
    {
        return await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetListAsync(Guid? userId = null, int pageNum = 0, int pageSize = 50)
    {
        return await _context.Orders
            .Where(o => userId == null || o.UserId == userId)
            .Skip(pageNum * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order order)
    {
        _context.Orders.Remove(order);

        await _context.SaveChangesAsync();
    }
}
