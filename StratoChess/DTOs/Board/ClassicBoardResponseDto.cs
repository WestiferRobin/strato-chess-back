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

        //public char GetSquareFrom(HorizontalPostion horizontal, VerticalPostion vertical)
        //{
        //    return Board[(int)horizontal][(int)vertical];
        //}
	}
}

