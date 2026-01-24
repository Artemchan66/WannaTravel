using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.Logic.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordHasher _hasher;

    public AuthService(IUserRepository userRepo, IPasswordHasher hasher)
    {
        _userRepo = userRepo;
        _hasher = hasher;
    }

    public async Task<User?> Login(string name, string password)
    {
        var user = await _userRepo.ReadByName(name);
        if (user == null) return null;

        if (!_hasher.Verify(user.PasswordHash, password))
            return null;

        return user;
    }
}
