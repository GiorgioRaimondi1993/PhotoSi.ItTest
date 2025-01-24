using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Locations.UnitTest.Tests.RequestHandlers;

public class GetLocationRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing location
    ///  When GetLocationRequest is submitted for that location
    ///  Then the location information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetLocation_ExistingLocation_Success()
    {
        // ARRANGE

        Location expectedLocation = Scenario.Locations[ScenarioIds.LocationRiccione];
        GetLocationRequest request = new() { Id = expectedLocation.Id };

        // ACT

        LocationDto location = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(expectedLocation.Id, location.Id);
        Assert.Equal(expectedLocation.UserId, location.UserId);
        Assert.Equal(expectedLocation.City, location.City);
        Assert.Equal(expectedLocation.Province, location.Province);
        Assert.Equal(expectedLocation.Country, location.Country);
        Assert.Equal(expectedLocation.Address, location.Address);
        Assert.Equal(expectedLocation.Cap, location.Cap);
    }

    /// <summary>
    /// Given a not existing locationId
    ///  When GetLocationRequest is submitted for that location
    ///  Then null is returned
    /// </summary>
    [Fact]
    public async Task Should_GetLocation_NotExistingLocation_Success()
    {
        // ARRANGE

        GetLocationRequest request = new() { Id = Guid.NewGuid() };

        // ACT

        LocationDto location = await Mediator.Send(request);

        // ASSERT

        Assert.Null(location);
    }
}
