using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Requests;
using Xunit;

namespace PhotoSi.Orders.UnitTest.Tests;

public class CreateOrderRequestHandlerTest : OrderBaseTest
{
    /// <summary>
    /// Given a user
    ///  When CreateOrderRequest is submitted
    ///  Then the order is created
    /// </summary>
    [Fact]
    public async Task Should_CreateOrder_Success()
    {
        // ARRANGE

        Guid userId = Guid.NewGuid(),
             locationId = Guid.NewGuid(),
             productId = Guid.NewGuid();

        CreateOrderRequest request = new()
        {
            UserId = userId,
            LocationId = locationId,
            Products = [productId]
        };

        // ACT

        Guid orderId = await Mediator.Send(request);

        // ASSERT

        Assert.True(Scenario.Orders.TryGetValue(orderId, out Order order));

        Assert.Equal(userId, order.UserId);
        Assert.Equal(locationId, order.LocationId);
        Assert.Collection(order.Products, item => Assert.Equal(productId, item));
    }
}
