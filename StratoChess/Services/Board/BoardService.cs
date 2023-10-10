using System;
using StratoChess.Data;
using StratoChess.DTOs.Board;

namespace StratoChess.Services.Board
{
	public class BoardService : IBoardService
    {
        private readonly StratoChessDbContext context;

        public BoardService(StratoChessDbContext context)
        {
            this.context = context;
        }

        public ClassicBoardResponseDto GetClassicBoard(ClassicBoardRequestDto boardRequest)
        {
            throw new NotImplementedException();
        }

        public ClassicBoardResponseDto UpdateClassicBoard(UpdateClassicBoardDto updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}

