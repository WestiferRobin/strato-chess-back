using System;
namespace StratoChess.DTOs.Player.Sheet
{
	public class PlayerSheetRequestDto : PlayerCommandResponseDto
	{
		public PlayerSheetRequestDto() : base()
		{
		}

		public PlayerSheetRequestDto(Guid boardId, Guid playerId) : base(boardId, playerId)
		{
		}
	}
}

