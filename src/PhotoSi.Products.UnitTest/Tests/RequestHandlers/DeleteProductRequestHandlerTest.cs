using PhotoSi.Products.Application.Requests;
using PhotoSi.Products.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Products.UnitTest.Tests.RequestHandlers;
public class DeleteProductRequestHandlerTest : ProductBaseTest
{
    /// <summary>
    /// Given an existing product
    ///  When DeleteProductRequest is submitted for that product
    ///  Then the product is no more persisted
    /// </summary>
    [Fact]
    public async Task Should_Delete_ExistingProduct_Success()
    {
        // ARRANGE

        DeleteProductRequest request = new() { Id = ScenarioIds.AlbumProduct };

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.False(Scenario.Products.ContainsKey(ScenarioIds.AlbumProduct));
    }

    /// <summary>
    /// Given the id of a non existing product
    ///  When DeleteProductRequest is submitted for that id
    ///  Then do nothing
    /// </summary>
    [Fact]
    public async Task Should_Delete_NotExistingProduct_DoNothing()
    {
        // ARRANGE

        DeleteProductRequest request = new() { Id = Guid.NewGuid() };

        int productsCount = Scenario.Products.Count;

        // ACT

        await Mediator.Send(request);

        // ASSERT

        Assert.Equal(productsCount, Scenario.Products.Count);
    }
}
