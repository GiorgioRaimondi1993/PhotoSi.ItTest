using PhotoSi.Products.Application.Requests;
using PhotoSi.Products.UnitTest.Scenario;
using Xunit;

namespace PhotoSi.Products.UnitTest.Tests.RequestHandlers;
public class UpdateProductRequestHandlerTest : ProductBaseTest
{
    /// <summary>
    /// Given an existing product
    ///  When UpdateProductRequest is submitted for that product
    ///  Then the persisted entity is updated
    /// </summary>
    [Fact]
    public async Task Should_Update_ExistingProduct_Success()
    {
        // ARRANGE

        UpdateProductRequest request = new() { Name = "Foto Libro", Category = "Libri" };
        request.SetId(ScenarioIds.AlbumProduct);

        // ACT

        await Mediator.Send(request);

        // ASSERT

        var updatedProduct = Scenario.Products[ScenarioIds.AlbumProduct];

        Assert.Equal(request.Name, updatedProduct.Name);
        Assert.Equal(request.Category, updatedProduct.Category);
    }

    /// <summary>
    /// Given an invalid productId
    ///  When UpdateProductRequest is submitted for that productId
    ///  Then an exception should be thrown
    /// </summary>
    [Fact]
    public async Task Should_Update_NotExistingProduct_Error()
    {
        // ARRANGE

        UpdateProductRequest request = new() { Name = "Foto Libro", Category = "Libri" };
        request.SetId(Guid.NewGuid());

        // ACT
        // ASSERT

        await Assert.ThrowsAsync<Exception>(() => Mediator.Send(request));
    }
}
