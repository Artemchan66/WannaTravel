using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic;

public interface IUserLogic
{
    Task<IEnumerable<User>> ReadAllUsers();
}
