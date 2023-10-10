using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StratoChess.DTOs.Board;
using StratoChess.DTOs.Game;
using StratoChess.DTOs.Player;
using StratoChess.Services.Board;

namespace StratoChess.Controllers
{
    [Route("board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService service)
        {
            this.boardService = service;
        }

        [HttpPost("classic")]
        public IActionResult ViewClassicBoard(
            [FromBody] ClassicBoardRequestDto boardRequest
        )
        {
            ClassicBoardResponseDto result = this.boardService.GetClassicBoard(boardRequest);
            return Ok(result);
        }

        [HttpPut("classic")]
        public IActionResult UpdateClassicBoard(
            [FromBody] UpdateClassicBoardDto updateRequest
        )
        {
            ClassicBoardResponseDto result = this.boardService.UpdateClassicBoard(updateRequest);
            return Ok(result);
        }
    }
}
