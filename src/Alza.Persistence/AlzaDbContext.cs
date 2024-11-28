using Microsoft.EntityFrameworkCore;

namespace Alza.Persistence;

internal class AlzaDbContext : DbContext
{
    public AlzaDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlzaDbContext).Assembly);
    }
}