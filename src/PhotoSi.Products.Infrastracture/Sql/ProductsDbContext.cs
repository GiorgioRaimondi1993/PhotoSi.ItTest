using Microsoft.EntityFrameworkCore;
using PhotoSi.Products.Application.Models;

namespace PhotoSi.Products.Infrastracture.Sql;
public class ProductsDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    }
}
