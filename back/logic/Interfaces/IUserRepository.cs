using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();

    Task<User?> GetByUsername(string name);

    Task Create(User user);
}
