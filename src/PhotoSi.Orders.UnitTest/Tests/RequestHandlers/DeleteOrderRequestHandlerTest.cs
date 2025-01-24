using PhotoSi.Orders.Application.Requests;
using PhotoSi.Orders.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Orders.UnitTest.Tests.RequestHandlers;
public class DeleteOrderRequestHandlerTest : OrderBaseTest
{
    /// <summary>
    /// Given an existing order
    ///  When DeleteOrderRequest is submitted for that order
    ///  Then the order is no more persisted
    /// </summary>
    [Fact]
    public async Task Should_Delete_ExistingOrder_Success()
    {
        // ARRANGE

        DeleteOrderRequest request = new() { OrderId = ScenarioIds.OrderId };

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.False(Scenario.Orders.ContainsKey(ScenarioIds.OrderId));
    }

    /// <summary>
    /// Given the id of a non existing order
    ///  When DeleteOrderRequest is submitted for that id
    ///  Then do nothing
    /// </summary>
    [Fact]
    public async Task Should_Delete_NotExistingOrder_DoNothing()
    {
        // ARRANGE

        DeleteOrderRequest request = new() { OrderId = Guid.NewGuid() };

        int ordersCount = Scenario.Orders.Count;

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.Equal(ordersCount, Scenario.Orders.Count);
    }
}
