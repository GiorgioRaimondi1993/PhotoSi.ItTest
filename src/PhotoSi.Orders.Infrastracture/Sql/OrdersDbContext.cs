using Microsoft.EntityFrameworkCore;
using PhotoSi.Orders.Application.Models;

namespace PhotoSi.Orders.Infrastracture.Sql;
public class OrdersDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
    }
}
