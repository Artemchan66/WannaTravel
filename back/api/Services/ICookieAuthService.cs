using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.API.Services;

public interface ICookieAuthService
{
    Task<User?> Login(string username, string password);

    Task Logout();
}
