using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Models;

namespace INNOMIATE_API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Competition> Competitions {get; set;} = null!;
    public DbSet<Prize> Prizes {get; set;}  = null!;
    public DbSet<UserCompetition> UserCompetitions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the User entity
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Prize>().HasKey(p=> p.Id);
        modelBuilder.Entity<Competition>().HasKey(c=>c.Id);
        modelBuilder.Entity<UserCompetition>().HasKey(u=> u.UserId);

        // Add additional model configuration as needed
    }
}

