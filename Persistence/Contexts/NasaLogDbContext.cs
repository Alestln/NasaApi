using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class NasaLogDbContext(DbContextOptions<NasaLogDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "log";
    internal const string DbMigrationsHistoryTable = "__LogDbMigrationsHistory";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}