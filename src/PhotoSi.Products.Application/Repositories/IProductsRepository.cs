using PhotoSi.Products.Application.Models;

namespace PhotoSi.Products.Application.Repositories;

public interface IProductsRepository
{
    Task<Product> GetById(Guid id);

    Task<IEnumerable<Product>> GetListAsync(string category = null,
                                            int pageNum = 0,
                                            int pageSize = 50);

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}
