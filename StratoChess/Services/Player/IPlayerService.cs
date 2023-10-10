using StratoChess.DTOs.Player;
using StratoChess.DTOs.Player.Sheet;

namespace StratoChess.Services
{
    public interface IPlayerService
    {
        PlayerCommandResponseDto ExecutePlayerCommand(PlayerCommandRequestDto command);
        PlayerSheetResponseDto GetPlayerSheet(PlayerSheetRequestDto player);
    }
}