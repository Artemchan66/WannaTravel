using WannaTravel.Infrastructure.Entities;
using WannaTravel.Infrastructure.Repository;

namespace WannaTravel.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserRepository userRepository;

    public UserLogic(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> ReadAllUsers()
        => await userRepository.GetAll();
}
