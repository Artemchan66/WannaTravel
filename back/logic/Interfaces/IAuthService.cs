using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic.Interfaces;

public interface IAuthService
{
    Task<User?> Login(string name, string password);
}
