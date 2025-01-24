namespace PhotoSi.Users.Application.Models;

public class User
{
    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    // EF only
    protected User() { }

    // UT only
    public User(Guid id,
                   string firstName,
                   string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public static User Create(string firstName,
                              string lastName)
    {
        return new(Guid.NewGuid(),
                   firstName,
                   lastName);
    }

    public void Update(string firstName,
                       string lastName)
    {
        FirstName = firstName ?? FirstName;
        LastName = lastName ?? LastName;
    }
}
