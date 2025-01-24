using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Locations.UnitTest.Tests.RequestHandlers;
public class UpdateLocationRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing location
    ///  When UpdateLocationRequest is submitted for that location
    ///  Then the persisted entity is updated
    /// </summary>
    [Fact]
    public async Task Should_Update_ExistingLocation_Success()
    {
        // ARRANGE

        UpdateLocationRequest request = new()
        {
            City = "Milano",
            Province = "MI",
            Country = "ITA",
            Address = "Piazza Duomo 1",
            Cap = "20121"
        };
        request.SetId(ScenarioIds.LocationBasiglio);

        // ACT

        await Mediator.Send(request);

        // ASSERT

        var updatedLocation = Scenario.Locations[request.Id];

        Assert.Equal(request.City, updatedLocation.City);
        Assert.Equal(request.Province, updatedLocation.Province);
        Assert.Equal(request.Country, updatedLocation.Country);
        Assert.Equal(request.Address, updatedLocation.Address);
        Assert.Equal(request.Cap, updatedLocation.Cap);
    }

    /// <summary>
    /// Given an invalid locationId
    ///  When UpdateLocationRequest is submitted for that locationId
    ///  Then an exception should be thrown
    /// </summary>
    [Fact]
    public async Task Should_Update_NotExistingLocation_Error()
    {
        // ARRANGE

        UpdateLocationRequest request = new()
        {
            City = "Milano",
            Province = "MI",
            Country = "ITA",
            Address = "Piazza Duomo 1",
            Cap = "20121"
        };
        request.SetId(Guid.NewGuid());

        // ACT
        // ASSERT

        await Assert.ThrowsAsync<Exception>(() => Mediator.Send(request));
    }
}
