using StratoChess.Data;
using StratoChess.DTOs.Player;
using StratoChess.DTOs.Player.Sheet;

namespace StratoChess.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly StratoChessDbContext context;

        public PlayerService(StratoChessDbContext context)
        {
            this.context = context;
        }

        public PlayerCommandResponseDto ExecutePlayerCommand(PlayerCommandRequestDto command)
        {
            throw new NotImplementedException();
        }

        public PlayerSheetResponseDto GetPlayerSheet(PlayerSheetRequestDto player)
        {
            throw new NotImplementedException();
        }

        public PlayerSheetResponseDto GetPlayerSheet(PlayerResponseDto player)
        {
            throw new NotImplementedException();
        }
    }
}

// OLD EXAMPLE

//public PlayerResponseDto CreatePlayer(PlayerResponseDto playerDto)
//{
//    //if (playerDto == null)
//    //{
//    //    throw new ArgumentNullException(nameof(playerDto));
//    //}

//    //var player = new Player()
//    //{
//    //    Name = playerDto.Name
//    //};

//    //// Add logic to create a new player in the database
//    //// For example:
//    //var result = _context.Players.Add(player);
//    //_context.SaveChanges();

//    var resultPlayer = new PlayerResponseDto();

//    // Return the created player with its assigned ID
//    return resultPlayer;
//}

//public IEnumerable<PlayerResponseDto?> GetAllPlayers()
//{
//    // Retrieve all players from the database
//    var players = new List<PlayerResponseDto?>();
//    //foreach (var player in _context.Players)
//    //{
//    //    players.Add(new PlayerDto()
//    //    {
//    //        Name = player.Name,
//    //    });
//    //}
//    return players;
//}

//public PlayerResponseDto? GetPlayerById(int id)
//{
//    // Retrieve a player by ID from the database
//    //var player = _context.Players.Find(id);

//    //// Return null if the player is not found
//    //if (player == null)
//    //{
//    //    return null;
//    //}

//    //// You can perform additional logic here if needed
//    var playerDto = new PlayerResponseDto();
//    return playerDto;
//}