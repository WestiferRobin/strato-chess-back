using StratoChess.Data;
using StratoChess.DTOs;
using StratoChess.Models;

namespace StratoChess.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public PlayerDto CreatePlayer(PlayerDto playerDto)
        {
            if (playerDto == null)
            {
                throw new ArgumentNullException(nameof(playerDto));
            }

            var player = new Player()
            {
                Name = playerDto.Name
            };

            // Add logic to create a new player in the database
            // For example:
            var result = _context.Players.Add(player);
            _context.SaveChanges();

            var resultPlayer = new PlayerDto()
            {
                Name = result.Entity.Name
            };

            // Return the created player with its assigned ID
            return resultPlayer;
        }

        public IEnumerable<PlayerDto?> GetAllPlayers()
        {
            // Retrieve all players from the database
            var players = new List<PlayerDto?>();
            foreach (var player in _context.Players)
            {
                players.Add(new PlayerDto()
                {
                    Name = player.Name,
                });
            }
            return players;
        }

        public PlayerDto? GetPlayerById(int id)
        {
            // Retrieve a player by ID from the database
            var player = _context.Players.Find(id);

            // Return null if the player is not found
            if (player == null)
            {
                return null;
            }

            // You can perform additional logic here if needed
            var playerDto = new PlayerDto()
            {
                Name = player.Name
            };
            return playerDto;
        }
    }
}
