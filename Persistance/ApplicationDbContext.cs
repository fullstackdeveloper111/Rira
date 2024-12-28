using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistance.Configuration;

namespace Persistance;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<User> Users { get; set; }
}
