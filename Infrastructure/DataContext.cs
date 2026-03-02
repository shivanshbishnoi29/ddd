using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<State>()
            .HasQueryFilter(x => x.IsActive);
    }
}
