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
            // Configure your model relationships and constraints here
        }
    }
}
