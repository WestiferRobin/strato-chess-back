using Microsoft.AspNetCore.Mvc;
using StratoChess.DTOs.Game;
using StratoChess.Services.Game;

namespace StratoChess.Controllers
{
    [Route("game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpPost("classic")]
        public IActionResult PostClassicGame(
            [FromBody] InitClassicGameDto config
        )
        {
            ClassicGameDto result = this.gameService.CreateClassicGame(config);
            return Ok(result);
        }

        [HttpGet("classic/{sessionId}")]
        public IActionResult GetClassicGame(Guid sessionId)
        {
            ClassicGameViewDto result = this.gameService.ViewClassicGame(sessionId);
            return Ok(result);
        }

        [HttpDelete("classic/{sessionId}")]
        public IActionResult DeleteClassicGame(Guid sessionId)
        {
            if (!this.gameService.DeleteClassicGame(sessionId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
