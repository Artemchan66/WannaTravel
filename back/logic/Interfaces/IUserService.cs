using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> ReadAllUsers();

    Task<User> Create(string name, string password);
}
