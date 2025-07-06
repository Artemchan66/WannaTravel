using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic.models;

namespace WannaTravel.Logic;

public interface IUserLogic
{
    Task<IEnumerable<User>> ReadAllUsers();

    Task<UserValidationModel> IsValid(string email, string password);
}
