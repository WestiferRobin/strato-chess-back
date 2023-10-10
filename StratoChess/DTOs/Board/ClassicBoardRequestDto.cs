using System;
namespace StratoChess.DTOs.Board
{
	public class ClassicBoardRequestDto
	{
		public Guid SessionId { get; set; }
		public Guid BoardId { get; set; }

		public ClassicBoardRequestDto()
		{
		}

		public ClassicBoardRequestDto(
			Guid sessionId,
			Guid boardId
		)
		{
			this.SessionId = sessionId;
			this.BoardId = boardId;
		}
	}
}

