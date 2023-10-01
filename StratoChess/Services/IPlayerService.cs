using StratoChess.Models;
using System.Collections.Generic;

namespace StratoChess.Services
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        Player CreatePlayer(Player player);
        // Add other service methods as needed
    }
}