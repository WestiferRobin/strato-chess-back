using Microsoft.EntityFrameworkCore;
using StratoChess.Models;
using StratoChess.Models.Player;
using StratoChess.Models.Player.Prism;
using StratoChess.Models.Player.User;

namespace StratoChess.Data
{
    public class StratoChessDbContext : DbContext
    {
        public StratoChessDbContext(DbContextOptions<StratoChessDbContext> options) : base(options)
        {
        }

        public DbSet<PrismModel> Prisms { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserPlayer> UserPlayers { get; set; }
        public DbSet<PrismPlayer> PrismPlayers { get; set; }
        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<PlayerTheme> PlayerThemes { get; set; }
        public DbSet<BoardModel> Boards { get; set; }
        public DbSet<SessionModel> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrismModel>().HasKey(p => p.Id);
            modelBuilder.Entity<PrismModel>().Property(p => p.Template).IsRequired();

            modelBuilder.Entity<UserModel>().HasKey(u => u.Id);
            modelBuilder.Entity<UserModel>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.Username).IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.Password).IsRequired();

            modelBuilder.Entity<PlayerModel>().HasKey(p => p.Id);
            modelBuilder.Entity<PlayerModel>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<PlayerModel>().Property(p => p.PlayerRank).IsRequired();
            modelBuilder.Entity<PlayerModel>().Property(p => p.ThemeId).IsRequired();

            modelBuilder.Entity<UserPlayer>()
                .HasBaseType<PlayerModel>() // Specify PlayerModel as the base type
                .HasOne(up => up.User)
                .WithMany()
                .HasForeignKey(up => up.UserId);
            modelBuilder.Entity<UserPlayer>().Property(up => up.UserId).IsRequired();

            modelBuilder.Entity<PrismPlayer>()
                .HasBaseType<PlayerModel>() // Specify PlayerModel as the base type
                .HasOne(pp => pp.Prism)
                .WithMany()
                .HasForeignKey(pp => pp.PrismId);

            modelBuilder.Entity<PlayerTheme>().HasKey(pt => pt.Id);
            modelBuilder.Entity<PlayerTheme>().Property(pt => pt.PrimaryColor).IsRequired();
            modelBuilder.Entity<PlayerTheme>().Property(pt => pt.SecondaryColor).IsRequired();

            modelBuilder.Entity<BoardModel>().HasKey(b => b.Id);
            modelBuilder.Entity<BoardModel>().Property(b => b.SessionId).IsRequired();
            modelBuilder.Entity<BoardModel>().Property(b => b.WhiteId).IsRequired();
            modelBuilder.Entity<BoardModel>().Property(b => b.BlackId).IsRequired();

            modelBuilder.Entity<SessionModel>().HasKey(s => s.Id);
            modelBuilder.Entity<SessionModel>().Property(s => s.CreatedAt).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
