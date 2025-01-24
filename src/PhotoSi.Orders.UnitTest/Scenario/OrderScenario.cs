using PhotoSi.Orders.Application.Models;

namespace PhotoSi.Orders.UnitTest.Scenario;
public class OrderScenario
{
    public Dictionary<Guid, Order> Orders { get; private set; } = [];

    public OrderScenario()
    {
        Orders[ScenarioIds.OrderId] = new(ScenarioIds.OrderId,
                                          ScenarioIds.UserIdWithOrder,
                                          Guid.NewGuid(),
                                          Guid.NewGuid().ToString());
    }
}

