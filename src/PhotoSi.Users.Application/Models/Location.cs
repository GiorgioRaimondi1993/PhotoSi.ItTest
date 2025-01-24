namespace PhotoSi.Users.Application.Models;

public class Location
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string City { get; private set; }

    public string Province { get; private set; }

    public string Country { get; private set; }

    public string Address { get; private set; }

    public string Cap { get; private set; }

    // EF only
    protected Location() { }

    protected Location(Guid id,
                       Guid userId,
                       string city,
                       string province,
                       string country,
                       string address,
                       string cap)
    {
        Id = id;
        UserId = userId;
        City = city;
        Province = province;
        Country = country;
        Address = address;
        Cap = cap;
    }

    public static Location Create(Guid userId,
                                  string city,
                                  string province,
                                  string country,
                                  string address,
                                  string cap)
    {
        return new(Guid.NewGuid(),
                   userId,
                   city,
                   province,
                   country,
                   address,
                   cap);
    }

    public void Update(string city,
                       string province,
                       string country,
                       string address,
                       string cap)
    {
        City = city ?? City;
        Province = province ?? Province;
        Country = country ?? Country;
        Address = address ?? Address;
        Cap = cap ?? Cap;
    }
}
