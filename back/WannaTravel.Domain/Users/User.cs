namespace WannaTravel.Infrastructure.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;

    public User(string name, string passwordHash)
    {
        Id = Guid.NewGuid();
        Name = name;
        PasswordHash = passwordHash;
    }
}
