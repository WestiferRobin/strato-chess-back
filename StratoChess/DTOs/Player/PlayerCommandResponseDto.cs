using System;
namespace StratoChess.DTOs.Player
{
	public class PlayerCommandResponseDto
    {
        public Guid BoardId { get; set; }
        public Guid PlayerId { get; set; }

        public PlayerCommandResponseDto()
        {
        }

        public PlayerCommandResponseDto(Guid boardId, Guid playerId)
        {
            this.BoardId = boardId;
            this.PlayerId = playerId;
        }
    }
}

