using PhotoSi.Users.Application.Models;
using PhotoSi.Users.Application.Requests;
using Xunit;

namespace PhotoSi.Users.UnitTest.Tests.RequestHandlers;

public class CreateUserRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given a new user
    ///  When CreateUserRequest is submitted
    ///  Then the user is created
    /// </summary>
    [Fact]
    public async Task Should_CreateUser_Success()
    {
        // ARRANGE

        CreateUserRequest request = new()
        {
            FirstName = "Luigi",
            LastName = "Bianchi"
        };

        // ACT

        Guid userId = await Mediator.Send(request);

        // ASSERT

        Assert.True(Scenario.Users.TryGetValue(userId, out User user));

        Assert.Equal(userId, user.Id);
        Assert.Equal(request.FirstName, user.FirstName);
        Assert.Equal(request.LastName, user.LastName);
    }
}
