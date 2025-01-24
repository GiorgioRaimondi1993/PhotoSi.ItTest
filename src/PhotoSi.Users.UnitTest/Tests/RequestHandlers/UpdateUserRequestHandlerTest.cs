using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Users.UnitTest.Tests.RequestHandlers;
public class UpdateUserRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing user
    ///  When UpdateUserRequest is submitted for that user
    ///  Then the persisted entity is updated
    /// </summary>
    [Fact]
    public async Task Should_Update_ExistingUser_Success()
    {
        // ARRANGE

        UpdateUserRequest request = new() { FirstName = "Marco", LastName = "Verdi" };
        request.SetId(ScenarioIds.UserWithLocation);

        // ACT

        await Mediator.Send(request);

        // ASSERT

        var updatedUser = Scenario.Users[ScenarioIds.UserWithLocation];

        Assert.Equal(request.FirstName, updatedUser.FirstName);
        Assert.Equal(request.LastName, updatedUser.LastName);
    }

    /// <summary>
    /// Given an invalid userId
    ///  When UpdateUserRequest is submitted for that userId
    ///  Then an exception should be thrown
    /// </summary>
    [Fact]
    public async Task Should_Update_NotExistingUser_Error()
    {
        // ARRANGE

        UpdateUserRequest request = new() { FirstName = "Marco", LastName = "Verdi" };
        request.SetId(Guid.NewGuid());

        // ACT
        // ASSERT

        await Assert.ThrowsAsync<Exception>(() => Mediator.Send(request));
    }
}
