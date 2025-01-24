using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Requests;
using PhotoSi.Users.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Users.UnitTest.Tests.RequestHandlers;

public class GetUserRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing user
    ///  When GetUserRequest is submitted for that user
    ///  Then the user information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetUser_ExistingUser_Success()
    {
        // ARRANGE

        User expectedUser = Scenario.Users[ScenarioIds.UserWithLocation];
        GetUserRequest request = new() { Id = expectedUser.Id };

        // ACT

        UserDto user = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(expectedUser.Id, user.Id);
        Assert.Equal(expectedUser.FirstName, user.FirstName);
        Assert.Equal(expectedUser.LastName, user.LastName);
    }

    /// <summary>
    /// Given a not existing userId
    ///  When GetUserRequest is submitted for that user
    ///  Then null is returned
    /// </summary>
    [Fact]
    public async Task Should_GetUser_NotExistingUser_Success()
    {
        // ARRANGE

        GetUserRequest request = new() { Id = Guid.NewGuid() };

        // ACT

        UserDto user = await Mediator.Send(request);

        // ASSERT

        Assert.Null(user);
    }
}
