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
            var playerDtos = players.Select(player => new PlayerDto
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                // Map other properties as needed
            });
            return Ok(playerDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayerById(int id)
        {
            // var player = _playerService.GetPlayerById(id);
            // if (player == null)
            // {
            //     return NotFound();
            // }

            var playerDto = new PlayerDto
            {
                Id = 0,
                FirstName = "Wes",
                LastName = "Webb"
                // Id = player.Id,
                // FirstName = player.FirstName,
                // LastName = player.LastName,
                // // Map other properties as needed
            };

            return Ok(playerDto);
        }

        [HttpPost]
        public IActionResult CreatePlayer([FromBody] PlayerDto playerDto)
        {
            var player = new Player
            {
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                // Map other properties as needed
            };

            var createdPlayer = _playerService.CreatePlayer(player);
            return CreatedAtAction(nameof(GetPlayerById), new { id = createdPlayer.Id }, createdPlayer);
        }

        // Other CRUD actions and route definitions...
    }
}
