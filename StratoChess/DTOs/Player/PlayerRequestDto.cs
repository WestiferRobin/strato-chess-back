using System;
using StratoChess.DTOs.Player.Sheet;
using StratoChess.Enums;

namespace StratoChess.DTOs.Player
{
	public class PlayerRequestDto
	{
		public string Name { get; set; }
		public PlayerThemeDto? Theme { get; set; }
		public PlayerType PlayerType { get; set; }

		public PlayerRequestDto()
		{
		}

		public PlayerRequestDto(string name, PlayerType type)
		{
			this.Name = name;
			this.PlayerType = type;
		}
	}
}

