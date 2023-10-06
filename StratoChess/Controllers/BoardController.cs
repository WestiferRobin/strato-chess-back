using System;
using Microsoft.AspNetCore.Mvc;
using StratoChess.DTOs;
using StratoChess.Services;

namespace StratoChess.Controllers
{
    [Route("board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        public BoardController()
        {
        }

        [HttpGet]
        public IActionResult GetBoard()
        {
            return Ok(new BoardDto());
        }
    }
}

