using PhotoSi.Products.Application.Requests;
using PhotoSi.Products.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Products.UnitTest.Tests.RequestHandlers;
public class GetProductsRequestHandlerTest : ProductBaseTest
{
    /// <summary>
    /// Given an existing product
    ///  When GetProductsRequest is submitted
    ///  Then the product information are returned
    /// </summary>
    [Fact]
    public async Task Should_GetProduct_ExistingProduct_Success()
    {
        // ARRANGE

        GetProductsRequest request = new() { PageNum = 0, PageSize = Scenario.Products.Count };

        // ACT

        IEnumerable<ProductDto> products = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(Scenario.Products.Count, products.Count());
    }

    /// <summary>
    /// Given a product category
    ///  When GetProductsRequest is submitted for that category
    ///  Then all product with that category are returned
    /// </summary>
    [Fact]
    public async Task Should_GetProduct_NotExistingProduct_Success()
    {
        // ARRANGE

        string category = Scenario.Products[ScenarioIds.AlbumProduct].Category;
        GetProductsRequest request = new() { PageNum = 0, PageSize = Scenario.Products.Count, Category = category };
        int productCountForUser = Scenario.Products.Values.Count(o => o.Category == request.Category);

        // ACT

        IEnumerable<ProductDto> products = await Mediator.Send(request);

        // ASSERT

        Assert.Equal(productCountForUser, products.Count());
        foreach (var product in products)
        {
            Assert.Equal(request.Category, product.Category);
        }
    }
}
