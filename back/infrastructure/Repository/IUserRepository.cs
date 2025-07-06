using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Infrastructure.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();

    Task<User?> GetByEmail(string email);
}
