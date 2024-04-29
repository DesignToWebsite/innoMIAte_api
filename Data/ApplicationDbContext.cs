using Microsoft.EntityFrameworkCore;
using INNOMIATE_API.Models;

namespace INNOMIATE_API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the User entity
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        // Add additional model configuration as needed
    }
}
