using Microsoft.EntityFrameworkCore;
using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<UserCountry> UserCountry { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => base.OnModelCreating(modelBuilder);
}
