using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic.Interfaces;

public interface IUserCountryRepository
{
    Task<List<UserCountry>> GetByUserId(Guid userId);
    Task<UserCountry?> Get(Guid userId, string country);
    Task Add(UserCountry userCountry);
    Task Update(UserCountry userCountry);
    Task Remove(UserCountry userCountry);
}

