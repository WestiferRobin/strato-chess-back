using System;
namespace StratoChess.DTOs.Game
{
	public class ClassicGameViewDto
	{
        public Guid WhiteId { get; set; }
        public Guid BlackId { get; set; }
        public Guid BoardId { get; set; }

        public ClassicGameViewDto() { }

        public ClassicGameViewDto(
            Guid whiteId,
            Guid blackId,
            Guid boardId
        )
        {
            this.WhiteId = whiteId;
            this.BlackId = blackId;
            this.BoardId = boardId;
        }
    }
}

