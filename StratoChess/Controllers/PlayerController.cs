using Microsoft.AspNetCore.Mvc;
using StratoChess.Models;
using StratoChess.Services;
using StratoChess.DTOs;
using System.Linq;

namespace StratoChess.Controllers
{
    [Route("players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var players = _playerService.GetAllPlayers();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayerById(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        public IActionResult CreatePlayer([FromBody] PlayerDto player)
        {
            var createdPlayer = _playerService.CreatePlayer(player);
            return Ok(createdPlayer);
        }
    }
}
