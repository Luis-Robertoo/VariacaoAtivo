using Microsoft.EntityFrameworkCore;
using VariacaoAtivo.API.Entities;

namespace VariacaoAtivo.API.Repositories;

public class DataBaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<AssetValue> AssetValue { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Principal"),
        provider => provider.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetValue>().Property(av => av.Value).HasPrecision(29, 20);
    }
}
