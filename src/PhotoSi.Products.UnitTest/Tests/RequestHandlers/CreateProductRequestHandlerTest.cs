using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Requests;
using Xunit;

namespace PhotoSi.Products.UnitTest.Tests.RequestHandlers;

public class CreateProductRequestHandlerTest : ProductBaseTest
{
    /// <summary>
    /// Given a user
    ///  When CreateProductRequest is submitted
    ///  Then the product is created
    /// </summary>
    [Fact]
    public async Task Should_CreateProduct_Success()
    {
        // ARRANGE

        CreateProductRequest request = new()
        {
            Name = "Foto Singola",
            Category = "Stampe"
        };

        // ACT

        Guid productId = await Mediator.Send(request);

        // ASSERT

        Assert.True(Scenario.Products.TryGetValue(productId, out Product product));

        Assert.Equal(request.Name, product.Name);
        Assert.Equal(request.Category, product.Category);
    }
}
