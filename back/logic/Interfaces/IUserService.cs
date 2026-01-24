using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic.Interfaces;

public interface IUserService
{
    Task<User?> ReadById(Guid id);

    Task<User> Create(string name, string password);
}
