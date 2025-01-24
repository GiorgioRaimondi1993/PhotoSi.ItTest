using Microsoft.EntityFrameworkCore;
using PhotoSi.Users.Application.Models;

namespace PhotoSi.Users.Infrastracture.Sql;
public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());
    }
}
