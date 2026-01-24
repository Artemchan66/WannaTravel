using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.Logic.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepo;
    private readonly IPasswordHasher hasher;

    public AuthService(IUserRepository userRepo, IPasswordHasher hasher)
    {
        this.userRepo = userRepo;
        this.hasher = hasher;
    }

    public async Task<User?> Login(string username, string password)
    {
        var user = await userRepo.GetByUsername(username);
        if (user == null) return null;

        if (!hasher.Verify(user.PasswordHash, password))
            return null;

        return user;
    }
}
