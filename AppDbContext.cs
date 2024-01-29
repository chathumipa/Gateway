using Microsoft.EntityFrameworkCore;
using TestSPA;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } // Assign a default value

    // Other DbSet properties can be added here

    // Other configurations, methods, etc.

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Students = Set<Student>();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add your model configurations here
        modelBuilder.Entity<Student>().ToTable("Students");
    }
}

