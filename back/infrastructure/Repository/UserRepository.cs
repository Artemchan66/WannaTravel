using Microsoft.EntityFrameworkCore;
using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Infrastructure.Repository;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<IEnumerable<User>> GetAll()
        => await appDbContext.Users.ToListAsync();
}
