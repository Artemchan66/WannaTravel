using WannaTravel.Infrastructure.Entities;
using WannaTravel.Infrastructure.Repository;
using WannaTravel.Logic.models;

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

    public async Task<UserValidationModel> IsValid(string email, string password)
    {
        UserValidationModel res = new();
        var existingUser = await userRepository.GetByEmail(email);

        if (existingUser != null)
        {
            res.IsEmailFound = true;
            if (existingUser.Password == password)
                res.IsPasswordCorrect = true;
        }
        return res;
    }
}
