using Microsoft.EntityFrameworkCore;
using Registration.Infrastructure.Data.Seeds;
using Registration.Infrastructure.Entities;

namespace Registration.Infrastructure.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options): base(options) 
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SuperUser();
        base.OnModelCreating(modelBuilder);
    }
}
