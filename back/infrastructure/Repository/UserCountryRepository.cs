using WannaTravel.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using WannaTravel.Infrastructure.Data;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.Infrastructure.Repository;

public class UserCountryRepository : IUserCountryRepository
{
    private readonly AppDbContext db;

    public UserCountryRepository(AppDbContext db)
    {
        this.db = db;
    }

    public Task<List<UserCountry>> GetByUserId(Guid userId) =>
        db.UserCountry
          .Where(x => x.UserId == userId)
          .ToListAsync();

    public Task<UserCountry?> Get(Guid userId, string country) =>
        db.UserCountry
          .FirstOrDefaultAsync(x => x.UserId == userId && x.CountryName == country);

    public async Task Add(UserCountry userCountry)
    {
        db.UserCountry.Add(userCountry);
        await db.SaveChangesAsync();
    }

    public async Task Update(UserCountry userCountry)
    {
        db.UserCountry.Update(userCountry);
        await db.SaveChangesAsync();
    }

    public async Task Remove(UserCountry userCountry)
    {
        db.UserCountry.Remove(userCountry);
        await db.SaveChangesAsync();
    }
}