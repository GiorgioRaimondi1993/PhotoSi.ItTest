using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Requests;
using PhotoSi.Orders.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Orders.UnitTest.Tests.RequestHandlers;

public class GetOrderRequestHandlerTest : OrderBaseTest
{
    /// <summary>
    /// Given an existing order
    ///  When GetOrderRequest is submitted for that order
    ///  Then the order information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetOrder_ExistingOrder_Success()
    {
        // ARRANGE

        Order expectedOrder = Scenario.Orders[ScenarioIds.OrderId];
        GetOrderRequest request = new() { Id = expectedOrder.Id };

        // ACT

        OrderDto order = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(expectedOrder.Id, order.Id);
        Assert.Equal(expectedOrder.UserId, order.UserId);
        Assert.Equal(expectedOrder.LocationId, order.LocationId);
        Assert.Equal(expectedOrder.Products.FirstOrDefault(), order.Products.FirstOrDefault());
    }

    /// <summary>
    /// Given a not existing orderId
    ///  When GetOrderRequest is submitted for that order
    ///  Then null is returned
    /// </summary>
    [Fact]
    public async Task Should_GetOrder_NotExistingOrder_Success()
    {
        // ARRANGE

        GetOrderRequest request = new() { Id = Guid.NewGuid() };

        // ACT

        OrderDto order = await Mediator.Send(request);

        // ASSERT

        Assert.Null(order);
    }
}
