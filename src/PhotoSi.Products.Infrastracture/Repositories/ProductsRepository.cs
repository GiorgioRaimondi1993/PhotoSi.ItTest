using Microsoft.EntityFrameworkCore;
using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.Infrastracture.Sql;

namespace PhotoSi.Products.Infrastracture.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ProductsDbContext _context;

    public ProductsRepository(ProductsDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _context.Products.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Product>> GetListAsync(string category = null, int pageNum = 0, int pageSize = 50)
    {
        return await _context.Products
            .Where(o => category == null || o.Category == category)
            .Skip(pageNum * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }
}
