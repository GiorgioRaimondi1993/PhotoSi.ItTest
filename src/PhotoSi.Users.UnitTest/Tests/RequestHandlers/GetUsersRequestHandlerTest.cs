using PhotoSi.Users.Application.Requests;
using Xunit;

namespace PhotoSi.Users.UnitTest.Tests.RequestHandlers;
public class GetUsersRequestHandlerTest : UserBaseTest
{
    /// <summary>
    /// Given an existing user
    ///  When GetUsersRequest is submitted
    ///  Then the user information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetUser_ExistingUser_Success()
    {
        // ARRANGE

        GetUsersRequest request = new() { PageNum = 0, PageSize = Scenario.Users.Count };

        // ACT

        IEnumerable<UserDto> users = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(Scenario.Users.Count, users.Count());
    }
}
