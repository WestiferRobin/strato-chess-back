using System;
namespace StratoChess.DTOs.Game
{
	public class ClassicGameDto
	{
		public ClassicGameViewDto View { get; set; }
		public Guid SessionId { get; set; }

		public ClassicGameDto() { }

		public ClassicGameDto(
			ClassicGameViewDto classicGameDto,
			Guid sessionId
		)
		{
			this.View = classicGameDto;
			this.SessionId = sessionId;
		}
	}
}

