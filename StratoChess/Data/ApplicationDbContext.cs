using Microsoft.EntityFrameworkCore;
using StratoChess.Models;

namespace StratoChess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        // Add other DbSet properties for your data models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example: Configuring a unique constraint on the Name property
            modelBuilder.Entity<Player>()
                .HasIndex(player => player.Name)
                .IsUnique();

            // Add any other model-specific configurations here

            base.OnModelCreating(modelBuilder);
        }
    }
}
