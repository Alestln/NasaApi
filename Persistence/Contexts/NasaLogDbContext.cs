using Core.Domain.NasaLogs.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class NasaLogDbContext(DbContextOptions<NasaLogDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "log";
    internal const string DbMigrationsHistoryTable = "__LogDbMigrationsHistory";

    public DbSet<LogRecord> LogRecords { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}