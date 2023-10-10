using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using StratoChess.DTOs.Player;
using StratoChess.DTOs.Player.Sheet;
using StratoChess.Services;

namespace StratoChess.Controllers
{
    [Route("player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpPost("sheet")]
        public IActionResult ViewPlayerSheet([FromBody] PlayerSheetRequestDto player)
        {
            PlayerSheetResponseDto result = this.playerService.GetPlayerSheet(player);
            return Ok(result);
        }

        [HttpPost("command")]
        public IActionResult CommandPlayer([FromBody] PlayerCommandRequestDto command)
        {
            PlayerCommandResponseDto result = this.playerService.ExecutePlayerCommand(command);
            return Ok(result);
        }
    }
}