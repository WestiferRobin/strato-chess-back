using Microsoft.EntityFrameworkCore.Infrastructure;
using StratoChess.Enums;

namespace StratoChess.Converter
{
	public static class BoardPositionConverter
	{
		public static int[,] GetIndexPosition(HorizontalPostion horizontal, VerticalPostion vertical)
		{
            var xPos = (int)horizontal;
			var yPos = (int)vertical;
			return new int[,]
			{
				{xPos },
				{yPos }
			};
		}

		public static int[,] GetIndexPosition(char horizontal, char vertical)
		{
            var hPos = char.ToUpper(horizontal) switch
            {
                'A' => HorizontalPostion.A,
                'B' => HorizontalPostion.B,
                'C' => HorizontalPostion.C,
                'D' => HorizontalPostion.D,
                'E' => HorizontalPostion.E,
                'F' => HorizontalPostion.F,
                'G' => HorizontalPostion.G,
                'H' => HorizontalPostion.H,
                _ => throw new ArgumentException($"Horizontal {horizontal} isn't valid notation for index"),
            };
            var vPos = char.ToUpper(vertical) switch
            {
                '1' => VerticalPostion.One,
                '2' => VerticalPostion.Two,
                '3' => VerticalPostion.Three,
                '4' => VerticalPostion.Four,
                '5' => VerticalPostion.Five,
                '6' => VerticalPostion.Six,
                '7' => VerticalPostion.Seven,
                '8' => VerticalPostion.Eight,
                _ => throw new ArgumentException($"Vertical {vertical} isn't valid notation for index"),
            };
            return GetIndexPosition(hPos, vPos);
        }

        public static int[,] GetIndexPosition(string notation)
        {
            if (!notation.Contains(':'))
            {
                throw new ArgumentException($"{notation} isn't valid notation for index");
            }
            var position = notation.Split(':');
            char hPos = position[0].ToCharArray()[0];
            char vPos = position[1].ToCharArray()[0];
            return GetIndexPosition(hPos, vPos);
        }
	}
}

