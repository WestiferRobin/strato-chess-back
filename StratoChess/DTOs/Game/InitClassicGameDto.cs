using System;
using StratoChess.DTOs.Player;
using StratoChess.Enums;

namespace StratoChess.DTOs.Game
{
	public class InitClassicGameDto
    {
		public PlayerRequestDto White { get; set; }
		public PlayerRequestDto Black { get; set; }
		public ClassicGameMode Mode { get; set; }

        public InitClassicGameDto()
		{
		}

		public InitClassicGameDto(
            PlayerRequestDto white,
            PlayerRequestDto black,
			ClassicGameMode mode
		)
		{
			this.White = white;
			this.Black = black;
			this.Mode = mode;
		}
	}
}

