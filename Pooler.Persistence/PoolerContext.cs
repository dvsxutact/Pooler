using Microsoft.EntityFrameworkCore;
using Pooler.Domain.Entities;

namespace Pooler.Persistence
{
    public class PoolerContext : DbContext
    {
        public PoolerContext(DbContextOptions<PoolerContext> options) : base(options)
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<PoolGame> PoolGames { get; set; }
        public DbSet<GameDetails> GameDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PoolerContext).Assembly);

            modelBuilder.Entity<Player>(player =>
            {
                player.Property(e => e.Name).HasMaxLength(150);
                player.Property(e => e.Name).IsRequired();

                player.Property(e => e.Email).HasMaxLength(200);
                player.Property(e => e.Email).IsRequired();

                player.HasIndex(e => e.AccountNumber).IsUnique();
                player.Property(e => e.AccountNumber).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<PoolGame>().ToTable("PoolGames");
            modelBuilder.Entity<GameDetails>().ToTable("GameDetails");


        }
    }
}
