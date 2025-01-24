using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Locations.UnitTest.Tests.RequestHandlers;
public class DeleteLocationRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing location
    ///  When DeleteLocationRequest is submitted for that location
    ///  Then the location is no more persisted
    /// </summary>
    [Fact]
    public async Task Should_Delete_ExistingLocation_Success()
    {
        // ARRANGE

        DeleteLocationRequest request = new() { Id = ScenarioIds.LocationBasiglio };

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.False(Scenario.Locations.ContainsKey(request.Id));
    }

    /// <summary>
    /// Given the id of a non existing location
    ///  When DeleteLocationRequest is submitted for that id
    ///  Then do nothing
    /// </summary>
    [Fact]
    public async Task Should_Delete_NotExistingLocation_DoNothing()
    {
        // ARRANGE

        DeleteLocationRequest request = new() { Id = Guid.NewGuid() };

        int locationsCount = Scenario.Locations.Count;

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.Equal(locationsCount, Scenario.Locations.Count);
    }
}
