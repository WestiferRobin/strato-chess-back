namespace StratoChess.DTOs.Player
{
    public class PlayerResponseDto
    {
        public Guid SessionId { get; set; }
        public Guid PlayerId { get; set; }

        public PlayerResponseDto() { }

        public PlayerResponseDto(Guid sessionId, Guid playerId)
        {
            this.SessionId = sessionId;
            this.PlayerId = playerId;
        }
    }
}
