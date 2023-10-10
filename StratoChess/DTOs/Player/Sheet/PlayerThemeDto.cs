using System;
namespace StratoChess.DTOs.Player.Sheet
{
	public class PlayerThemeDto
	{
		public string PrimaryColor { get; set; }
		public string SecondaryColor { get; set; }

		public PlayerThemeDto()
		{
		}

        public PlayerThemeDto(string primary, string secondary)
        {
			this.PrimaryColor = primary;
			this.SecondaryColor = secondary;
        }
    }
}

