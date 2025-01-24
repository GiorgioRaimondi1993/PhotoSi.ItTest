using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Users.UnitTest.Tests.RequestHandlers;
public class DeleteUserRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing user
    ///  When DeleteUserRequest is submitted for that user
    ///  Then the user is no more persisted
    /// </summary>
    [Fact]
    public async Task Should_Delete_ExistingUser_Success()
    {
        // ARRANGE

        DeleteUserRequest request = new() { Id = ScenarioIds.UserWithLocation };

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.False(Scenario.Users.ContainsKey(ScenarioIds.UserWithLocation));
    }

    /// <summary>
    /// Given the id of a non existing user
    ///  When DeleteUserRequest is submitted for that id
    ///  Then do nothing
    /// </summary>
    [Fact]
    public async Task Should_Delete_NotExistingUser_DoNothing()
    {
        // ARRANGE

        DeleteUserRequest request = new() { Id = Guid.NewGuid() };

        int usersCount = Scenario.Users.Count;

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.Equal(usersCount, Scenario.Users.Count);
    }
}
