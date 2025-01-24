using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.UnitTest.Scenario;

namespace PhotoSi.Products.UnitTest.Services;
public class MockProductsRepository : IProductsRepository
{
    private ProductsScenario _scenario;
    public MockProductsRepository(ProductsScenario scenario)
    {
        _scenario = scenario;
    }

    public Task AddAsync(Product product)
    {
        _scenario.Products.TryAdd(product.Id, product);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        _scenario.Products.Remove(product.Id);

        return Task.CompletedTask;
    }

    public Task<Product> GetById(Guid id)
    {
        Product product = _scenario.Products.Values.SingleOrDefault(o => o.Id == id);
        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> GetListAsync(string category = null, int pageNum = 0, int pageSize = 50)
    {
        IEnumerable<Product> products = _scenario.Products.Values
            .Where(p => category is null || p.Category == category)
            .Skip(pageNum * pageSize).Take(pageSize).ToList();

        return Task.FromResult(products);
    }

    public Task UpdateAsync(Product product)
    {
        _scenario.Products[product.Id] = product;

        return Task.CompletedTask;
    }
}
