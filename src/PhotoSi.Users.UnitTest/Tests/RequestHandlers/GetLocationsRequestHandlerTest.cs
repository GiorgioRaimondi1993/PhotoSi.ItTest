using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Locations.UnitTest.Tests.RequestHandlers;
public class GetLocationsRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing location
    ///  When GetLocationsRequest is submitted
    ///  Then the location information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetLocation_ExistingLocation_Success()
    {
        // ARRANGE

        GetLocationsRequest request = new() { PageNum = 0, PageSize = Scenario.Locations.Count };

        // ACT

        IEnumerable<LocationDto> locations = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(Scenario.Locations.Count, locations.Count());
    }

    /// <summary>
    /// Given a user with location
    ///  When GetLocationsRequest is submitted for that user
    ///  Then all user location are returned
    /// </summary>
    [Fact]
    public async Task Should_GetLocation_NotExistingLocation_Success()
    {
        // ARRANGE

        GetLocationsRequest request = new() { PageNum = 0, PageSize = Scenario.Locations.Count, UserId = ScenarioIds.UserWithLocation };
        int locationCountForUser = Scenario.Locations.Values.Count(o => o.UserId == request.UserId);

        // ACT

        IEnumerable<LocationDto> locations = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(locationCountForUser, locations.Count());
        foreach (var location in locations)
        {
            Assert.Equal(request.UserId, location.UserId);
        }
    }
}
