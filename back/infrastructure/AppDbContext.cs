using Microsoft.EntityFrameworkCore;
using WannaTravel.Infrastructure.Entities;

namespace WannaTravel.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    //public string DbPath { get; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //public AppDbContext()
    //{
    //    var folder = Environment.SpecialFolder.LocalApplicationData;
    //    var path = Environment.GetFolderPath(folder);
    //    DbPath = Path.Join(path, "wannatravel.db");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => base.OnModelCreating(modelBuilder);
}
