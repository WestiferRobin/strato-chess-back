using System;
using StratoChess.DTOs.Player;

namespace StratoChess.DTOs.Board
{
	public class UpdateClassicBoardDto
	{
		public ClassicBoardRequestDto BoardRequest { get; set; }
		public PlayerCommandRequestDto PlayerCommand { get; set; }

		public UpdateClassicBoardDto()
		{
		}

		public UpdateClassicBoardDto(
			ClassicBoardRequestDto boardRequest,
			PlayerCommandRequestDto playerCommand
		)
		{
			this.BoardRequest = boardRequest;
			this.PlayerCommand = playerCommand;
		}
	}
}

