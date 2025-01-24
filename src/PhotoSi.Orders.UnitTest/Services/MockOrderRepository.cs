using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.UnitTest.Scenario;

namespace PhotoSi.Orders.UnitTest.Services;
public class MockOrderRepository : IOrdersRepository
{
    private OrderScenario _scenario;
    public MockOrderRepository(OrderScenario scenario)
    {
        _scenario = scenario;
    }

    public Task AddAsync(Order order)
    {
        _scenario.Orders.TryAdd(order.Id, order);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Order order)
    {
        _scenario.Orders.Remove(order.Id);

        return Task.CompletedTask;
    }

    public Task<Order> GetById(Guid id)
    {
        Order order = _scenario.Orders.Values.SingleOrDefault(o => o.Id == id);
        return Task.FromResult(order);
    }

    public Task<IEnumerable<Order>> GetListAsync(Guid? userId = null, int pageNum = 0, int pageSize = 50)
    {
        IEnumerable<Order> orders = _scenario.Orders.Values
            .Where(o => userId is null || o.UserId == userId)
            .Skip(pageNum * pageSize).Take(pageSize).ToList();

        return Task.FromResult(orders);
    }

    public Task UpdateAsync(Order order)
    {
        _scenario.Orders[order.Id] = order;

        return Task.CompletedTask;
    }
}
