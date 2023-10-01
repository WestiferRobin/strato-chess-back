using StratoChess.Data;
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

        public Player CreatePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            // Add logic to create a new player in the database
            // For example:
            // _context.Players.Add(player);
            // _context.SaveChanges();

            // Return the created player with its assigned ID
            return player;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            // Retrieve all players from the database
            var players = _context.Players;

            // You can perform additional logic here if needed

            // return players;
            return new List<Player>();
        }

        public Player GetPlayerById(int id)
        {
            // Retrieve a player by ID from the database
            var player = _context.Players.Find(id);

            // Return null if the player is not found
            if (player == null)
            {
                return null;
            }

            // You can perform additional logic here if needed

            return player;
        }
    }
}
