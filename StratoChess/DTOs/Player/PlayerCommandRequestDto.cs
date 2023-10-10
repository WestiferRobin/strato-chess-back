using System;
namespace StratoChess.DTOs.Player
{
	public class PlayerCommandRequestDto
	{
		public Guid PlayerId { get; set; }
		public char PieceToken { get; set; }
		public string CurrentPosition { get; set; }
		public string TargetPosition { get; set; }

		public PlayerCommandRequestDto()
		{
		}

		public PlayerCommandRequestDto(
			Guid playerId,
			char pieceToken,
			string currentPosition,
			string targetPosition
		)
		{
			this.PlayerId = playerId;
			this.PieceToken = pieceToken;
			this.CurrentPosition = currentPosition;
			this.TargetPosition = targetPosition;
		}
	}
}

