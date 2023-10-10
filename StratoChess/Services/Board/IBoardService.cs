using System;
using StratoChess.DTOs.Board;

namespace StratoChess.Services.Board
{
    public interface IBoardService
    {
        ClassicBoardResponseDto GetClassicBoard(ClassicBoardRequestDto boardRequest);
        ClassicBoardResponseDto UpdateClassicBoard(UpdateClassicBoardDto updateRequest);
    }
}

