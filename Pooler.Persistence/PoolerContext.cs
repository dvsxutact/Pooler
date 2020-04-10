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
            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<PoolGame>().ToTable("PoolGames");
            modelBuilder.Entity<GameDetails>().ToTable("GameDetails");
        }
    }
}
