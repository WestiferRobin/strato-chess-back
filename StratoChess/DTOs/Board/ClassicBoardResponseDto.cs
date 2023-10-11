using System;
using StratoChess.Constants;
using StratoChess.Enums;

namespace StratoChess.DTOs.Board
{
	public class ClassicBoardResponseDto
	{
        public char[][] Board { get; set; }

		public ClassicBoardResponseDto()
		{
            Board = BoardConstants.InitalizeClassicBoard();
        }
	}
}

