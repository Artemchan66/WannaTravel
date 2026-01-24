using WannaTravel.Domain.Enums;
using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Logic.Interfaces;

public interface IUserCountryService
{
    Task<List<UserCountry>> GetUserMap(Guid userId);
    Task UpdateCountry(Guid userId, string country, UserCountryStatus? status);
}
