using StratoChess.DTOs;
using StratoChess.Models;
using System.Collections.Generic;

namespace StratoChess.Services
{
    public interface IPlayerService
    {
        IEnumerable<PlayerDto?> GetAllPlayers();
        PlayerDto? GetPlayerById(int id);
        PlayerDto CreatePlayer(PlayerDto player);
    }
}