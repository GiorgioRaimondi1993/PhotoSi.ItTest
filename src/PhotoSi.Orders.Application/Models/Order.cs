using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoSi.Orders.Application.Models;

public class Order
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string ProductsCsv { get; private set; }

    [NotMapped]
    public IEnumerable<Guid> Products => ProductsCsv.Split(",").Select(p => Guid.Parse(p));

    public Guid LocationId { get; private set; }

    // EF only
    protected Order()
    {
    }

    // UT only
    public Order(Guid id, Guid userId, Guid locationId, string productsCsv)
    {
        Id = id;
        UserId = userId;
        LocationId = locationId;
        ProductsCsv = productsCsv;
    }

    public static Order Create(Guid userId, Guid locationId, IEnumerable<Guid> products)
    {
        if (products is null || !products.Any())
            throw new Exception("Cannot set no products to order");

        return new(Guid.NewGuid(), userId, locationId, string.Join(",", products));
    }

    public void Update(Guid? locationId, IEnumerable<Guid> products)
    {
        if (products is not null && !products.Any())
            throw new Exception("Cannot set no products to order");

        LocationId = locationId ?? LocationId;
        ProductsCsv = products is null ? ProductsCsv : string.Join(",", products);
    }

}
