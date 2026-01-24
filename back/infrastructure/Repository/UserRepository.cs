using Microsoft.EntityFrameworkCore;
using WannaTravel.Infrastructure.Data;
using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.Infrastructure.Repository;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext db;

    public UserRepository(AppDbContext db)
    {
        this.db = db;
    }
    
    public async Task<IEnumerable<User>> ReadAll()
        => await db.Users.ToListAsync();
    
    public async Task<User?> ReadByName(string name)
        => await db.Users.FirstOrDefaultAsync(w => w.Name == name);
    
    public async Task<User?> ReadById(Guid id)
        => await db.Users.FirstOrDefaultAsync(w => w.Id == id);

    public async Task Create(User user)
    {
        db.Add(user);
        await db.SaveChangesAsync();
    }
}
