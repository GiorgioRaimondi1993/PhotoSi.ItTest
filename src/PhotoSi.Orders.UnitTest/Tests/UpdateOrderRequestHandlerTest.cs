using PhotoSi.Orders.Application.Requests;
using PhotoSi.Orders.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Orders.UnitTest.Tests;
public class UpdateOrderRequestHandlerTest : OrderBaseTest
{
    /// <summary>
    /// Given an existing order
    ///  When UpdateOrderRequest is submitted for that order
    ///  Then the persisted entity is updated
    /// </summary>
    [Fact]
    public async Task Should_Update_ExistingOrder_Success()
    {
        // ARRANGE

        Guid newLocationId = Guid.NewGuid(),
             newProductId = Guid.NewGuid();

        UpdateOrderRequest request = new() { LocationId = newLocationId, Products = [newProductId] };
        request.SetId(ScenarioIds.OrderId);

        // ACT

        await Mediator.Send(request);

        // ASSERT

        var updatedOrder = Scenario.Orders[ScenarioIds.OrderId];

        Assert.Equal(newLocationId, updatedOrder.LocationId);
        Assert.Collection(updatedOrder.Products, p => Assert.Equal(newProductId, p));
    }

    /// <summary>
    /// Given an invalid orderId
    ///  When UpdateOrderRequest is submitted for that orderId
    ///  Then an exception should be thrown
    /// </summary>
    [Fact]
    public async Task Should_Update_NotExistingOrder_Error()
    {
        // ARRANGE

        Guid newLocationId = Guid.NewGuid(),
             newProductId = Guid.NewGuid(),
             invalidOrderId = Guid.NewGuid();

        UpdateOrderRequest request = new() { LocationId = newLocationId, Products = [newProductId] };
        request.SetId(invalidOrderId);

        // ACT
        // ASSERT

        await Assert.ThrowsAsync<Exception>(() => Mediator.Send(request));
    }
}
