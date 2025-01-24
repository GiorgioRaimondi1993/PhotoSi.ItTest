namespace PhotoSi.Products.Application.Models;

public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Category { get; private set; }

    // EF only
    protected Product() { }

    // IT only
    public Product(Guid id,
                      string name,
                      string category)
    {
        Id = id;
        Name = name;
        Category = category;
    }

    public static Product Create(string name,
                                 string category)
    {
        return new(Guid.NewGuid(),
                   name,
                   category);
    }

    public void Update(string name,
                       string category)
    {
        Name = name ?? Name;
        Category = category ?? Category;
    }
}
