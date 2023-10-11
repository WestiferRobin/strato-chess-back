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
            var sessionId = boardRequest.SessionId;
            var boardId = boardRequest.BoardId;

            var sessionModel = context.Sessions
                .Where(session => session.Id == sessionId)
                .First() ?? throw new NullReferenceException($"{sessionId} Session is not found");

            var boardModel = context.Boards
                .Where(board => board.Id == boardId &&
                    board.SessionId == sessionId
                ).First() ?? throw new NullReferenceException($"{boardId} Board is not found");

            return new ClassicBoardResponseDto()
            {
                Board = boardModel.BoardData
            }
        }

        public ClassicBoardResponseDto UpdateClassicBoard(UpdateClassicBoardDto updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}

