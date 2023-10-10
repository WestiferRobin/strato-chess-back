using System;
using StratoChess.DTOs.Game;

namespace StratoChess.Services.Game
{
    public interface IGameService
    {
        ClassicGameDto CreateClassicGame(InitClassicGameDto config);
        bool DeleteClassicGame(Guid sessionId);
        ClassicGameViewDto ViewClassicGame(Guid sessionId);
    }
}

