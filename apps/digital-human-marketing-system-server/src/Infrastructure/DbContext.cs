using Microsoft.EntityFrameworkCore;
using .Infrastructure.Models;

namespace .Infrastructure;

public class DbContext : DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    public DbSet<BusinessAccountDbModel> BusinessAccounts { get; set; }

    public DbSet<DigitalHumanDbModel> DigitalHumen { get; set; }

    public DbSet<VoiceToneDbModel> VoiceTones { get; set; }

    public DbSet<DigitalHumanStatsDbModel> DigitalHumanStatsItems { get; set; }

    public DbSet<DigitalHumanKnowledgeBaseDbModel> DigitalHumanKnowledgeBases { get; set; }

    public DbSet<MarketingProductDbModel> MarketingProducts { get; set; }
}
