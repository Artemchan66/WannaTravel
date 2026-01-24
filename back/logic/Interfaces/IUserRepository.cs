using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic.Interfaces;

public interface IUserRepository
{
    Task<User?> ReadByName(string name);

    Task<User?> ReadById(Guid id);

    Task Create(User user);
}
