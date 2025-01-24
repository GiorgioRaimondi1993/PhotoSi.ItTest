using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Locations.UnitTest.Tests.RequestHandlers;

public class CreateLocationRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given a user
    ///  When CreateLocationRequest is submitted
    ///  Then the location is created
    /// </summary>
    [Fact]
    public async Task Should_CreateLocation_Success()
    {
        // ARRANGE

        CreateLocationRequest request = new()
        {
            UserId = ScenarioIds.UserWithLocation,
            City = "Milano",
            Province = "MI",
            Country = "ITA",
            Address = "Piazza Duomo 1",
            Cap = "20121"
        };

        // ACT

        Guid locationId = await Mediator.Send(request);

        // ASSERT

        Assert.True(Scenario.Locations.TryGetValue(locationId, out Location location));

        Assert.Equal(request.UserId, location.UserId);
        Assert.Equal(request.City, location.City);
        Assert.Equal(request.Province, location.Province);
        Assert.Equal(request.Country, location.Country);
        Assert.Equal(request.Address, location.Address);
        Assert.Equal(request.Cap, location.Cap);
    }
}
