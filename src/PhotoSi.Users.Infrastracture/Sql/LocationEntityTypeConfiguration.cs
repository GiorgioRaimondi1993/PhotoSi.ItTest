using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoSi.Users.Application.Models;

namespace PhotoSi.Users.Infrastracture.Sql;
public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations", "PhotoSi");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.UserId).IsRequired();
        builder.Property(o => o.City).IsRequired();
        builder.Property(o => o.Province).IsRequired();
        builder.Property(o => o.Country).IsRequired();
        builder.Property(o => o.Address).IsRequired();
        builder.Property(o => o.Cap).IsRequired();
    }
}
