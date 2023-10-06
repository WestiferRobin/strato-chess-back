using System;
namespace StratoChess.DTOs
{
	public class BoardDto
	{
		public List<List<char>> Board { get; set; }

		public BoardDto()
		{
            Board = new List<List<char>>
            {
                new() { 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' },
                new() { 'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
                new() { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new() { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new() { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new() { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new() { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
                new() { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' }
            };
        }
	}
}

