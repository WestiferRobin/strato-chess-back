using System;
namespace StratoChess.DTOs.Player.Sheet
{
    public class PlayerSheetResponseDto
	{
        public Player.PlayerResponseDto Player { get; set; }
        public string Name { get; set; }
        public long Ranking { get; set; }
        public PlayerThemeDto PlayerTheme { get; set; }
        public List<char> Graveyard { get; set; }
        public Dictionary<int, string> MoveHistory { get; set; }

		public PlayerSheetResponseDto()
		{
		}

        public PlayerSheetResponseDto(
            Player.PlayerResponseDto player,
            string name,
            long ranking,
            PlayerThemeDto theme,
            List<char> graveyard,
            Dictionary<int, string> moveHistory
        )
        {
            this.Player = player;
            this.Name = name;
            this.Ranking = ranking;
            this.PlayerTheme = theme;
            this.Graveyard = graveyard;
            this.MoveHistory = moveHistory;
        }
	}
}

