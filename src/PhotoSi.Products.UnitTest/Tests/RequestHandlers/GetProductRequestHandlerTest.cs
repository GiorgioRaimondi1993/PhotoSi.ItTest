using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Requests;
using PhotoSi.Products.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Products.UnitTest.Tests.RequestHandlers;

public class GetProductRequestHandlerTest : ProductBaseTest
{
    /// <summary>
    /// Given an existing product
    ///  When GetProductRequest is submitted for that product
    ///  Then the product information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetProduct_ExistingProduct_Success()
    {
        // ARRANGE

        Product expectedProduct = Scenario.Products[ScenarioIds.AlbumProduct];
        GetProductRequest request = new() { Id = expectedProduct.Id };

        // ACT

        ProductDto product = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(expectedProduct.Id, product.Id);
        Assert.Equal(expectedProduct.Name, product.Name);
        Assert.Equal(expectedProduct.Category, product.Category);
    }

    /// <summary>
    /// Given a not existing productId
    ///  When GetProductRequest is submitted for that product
    ///  Then null is returned
    /// </summary>
    [Fact]
    public async Task Should_GetProduct_NotExistingProduct_Success()
    {
        // ARRANGE

        GetProductRequest request = new() { Id = Guid.NewGuid() };

        // ACT

        ProductDto product = await Mediator.Send(request);

        // ASSERT

        Assert.Null(product);
    }
}
