using WannaTravel.Domain.Enums;
using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.Logic.Services;

public class UserCountryService : IUserCountryService
{
    private readonly IUserCountryRepository repo;

    public UserCountryService(IUserCountryRepository repo)
    {
        this.repo = repo;
    }

    public async Task<List<UserCountry>> GetUserMap(Guid userId)
        => await repo.GetByUserId(userId);

    public async Task UpdateCountry(Guid userId, string country, UserCountryStatus? status)
    {
        var existing = await repo.Get(userId, country);

        if (status == null)
        {
            if (existing != null)
                await repo.Remove(existing);
            return;
        }

        if (existing == null)
        {
            await repo.Add(new UserCountry
            {
                UserId = userId,
                CountryName = country,
                Status = status.Value
            });
            return;
        }

        existing.Status = status.Value;
        await repo.Update(existing);
    }
}

