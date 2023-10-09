using System;
using Microsoft.AspNetCore.Mvc;
using StratoChess.Converter;
using StratoChess.DTOs;
using StratoChess.Services;

namespace StratoChess.Controllers
{
    [Route("/board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        public BoardDto board = new();

        public BoardController()
        {
        }

        [HttpGet]
        public IActionResult GetBoard()
        {
            return Ok(board);
        }

        [HttpGet("{position}")]
        public IActionResult GetSquare(string position)
        {
            if (position.Length != 2) return NotFound($"position {position} isn't valid");
            var index = BoardPositionConverter.GetIndexPosition($"{position[0]}:{position[1]}");
            int col = index[0, 0];
            int row = index[1, 0];
            var square = board.Board[row][col];
            return Ok(square);
        }
    }
}

