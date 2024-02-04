using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        modelBuilder.Entity<User>().Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValue(DateTime.Now);
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

        modelBuilder.Entity<UserSession>().Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }

}