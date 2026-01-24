using WannaTravel.Logic.Interfaces;

namespace WannaTravel.Infrastructure.Security;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    public bool Verify(string hash, string password) => BCrypt.Net.BCrypt.Verify(password, hash);
}
