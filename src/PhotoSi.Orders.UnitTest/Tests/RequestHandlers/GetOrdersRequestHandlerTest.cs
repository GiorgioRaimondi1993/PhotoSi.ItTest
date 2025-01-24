using PhotoSi.Orders.Application.Requests;
using PhotoSi.Orders.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Orders.UnitTest.Tests.RequestHandlers;
public class GetOrdersRequestHandlerTest : OrderBaseTest
{
    /// <summary>
    /// Given an existing order
    ///  When GetOrdersRequest is submitted
    ///  Then the order information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetOrder_ExistingOrder_Success()
    {
        // ARRANGE

        GetOrdersRequest request = new() { PageNum = 0, PageSize = Scenario.Orders.Count };

        // ACT

        IEnumerable<OrderDto> orders = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(Scenario.Orders.Count, orders.Count());
    }

    /// <summary>
    /// Given a user with order
    ///  When GetOrdersRequest is submitted for that user
    ///  Then all user order are returned
    /// </summary>
    [Fact]
    public async Task Should_GetOrder_NotExistingOrder_Success()
    {
        // ARRANGE

        GetOrdersRequest request = new() { PageNum = 0, PageSize = Scenario.Orders.Count, UserId = ScenarioIds.UserIdWithOrder };
        int orderCountForUser = Scenario.Orders.Values.Count(o => o.UserId == request.UserId);

        // ACT

        IEnumerable<OrderDto> orders = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(orderCountForUser, orders.Count());
        foreach (var order in orders)
        {
            Assert.Equal(request.UserId, order.UserId);
        }
    }
}
