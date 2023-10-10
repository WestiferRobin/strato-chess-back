
using System;
namespace StratoChess.Constants
{
	public static class BoardConstants
	{
		public const int ClassicBoardWidth = 8;
		public const int ClassicBoardHeight = 8;

		public static char[][] InitalizeClassicBoard()
		{
            char[][] chessboard = new char[][]
            {
                new char[] { 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' },
                new char[] { 'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
                new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new char[] { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
                new char[] { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' }
            };
            return chessboard;
        }

	}
}

