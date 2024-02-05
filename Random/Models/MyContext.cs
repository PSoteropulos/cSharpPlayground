using Microsoft.EntityFrameworkCore;

namespace Random.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    // public DbSet<User> Users { get; set; }
    // public DbSet<Project> Projects { get; set; }
    // public DbSet<Support> Supports { get; set; }

}