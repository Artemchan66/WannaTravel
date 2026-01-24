using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.Logic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordHasher _hasher;

    public UserService(IUserRepository userRepo, IPasswordHasher hasher)
    {
        _userRepo = userRepo;
        _hasher = hasher;
    }

    public async Task<IEnumerable<User>> ReadAllUsers()
        => await _userRepo.GetAll();

    public async Task<User> Create(string name, string password)
    {
        var passwordHash = _hasher.Hash(password);
        var user = new User(name, passwordHash);
        await _userRepo.Create(user);
        return user;
    }
}
