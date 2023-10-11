using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using StratoChess.Data;
using StratoChess.DTOs.Game;
using StratoChess.Enums;
using StratoChess.Factories;
using StratoChess.Models;

namespace StratoChess.Services.Game
{
    public class GameService : IGameService
    {
        private readonly StratoChessDbContext context;

        public GameService(StratoChessDbContext context)
        {
            this.context = context;
        }

        public ClassicGameDto CreateClassicGame(InitClassicGameDto config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            PlayerModel white;
            PlayerModel black;

            switch (config.Mode)
            {
                case ClassicGameMode.UserVsPrism:
                    if (config.White.PlayerType == PlayerType.User &&
                        config.Black.PlayerType == PlayerType.Prism
                    )
                    {
                        white = PlayerModelFactory.CreateUserPlayer(context, config.White.Name);
                        black = PlayerModelFactory.CreatePrismPlayer(context, config.Black.Name);

                    }
                    else if (config.White.PlayerType == PlayerType.Prism &&
                        config.Black.PlayerType == PlayerType.User
                    )
                    {
                        white = PlayerModelFactory.CreatePrismPlayer(context, config.White.Name);
                        black = PlayerModelFactory.CreateUserPlayer(context, config.Black.Name);
                    }
                    else
                    {
                        throw new ArgumentException(
                            $"{config.White.Name} vs ${config.Black.Name}" +
                            $" isn't a valid UserVsPrism Configuration"
                        );
                    }
                    break;
                case ClassicGameMode.PrismVsPrism:
                    if (config.White.PlayerType == PlayerType.Prism &&
                        config.Black.PlayerType == PlayerType.Prism
                    )
                    {
                        white = PlayerModelFactory.CreatePrismPlayer(context, config.White.Name);
                        black = PlayerModelFactory.CreatePrismPlayer(context, config.Black.Name);

                    }
                    else
                    {
                        throw new ArgumentException(
                            $"{config.White.Name} vs ${config.Black.Name}" +
                            $" isn't a valid PrismVsPrism Configuration"
                        );
                    }
                    break;
                case ClassicGameMode.UserVsUser:
                    if (config.White.PlayerType == PlayerType.Prism &&
                        config.Black.PlayerType == PlayerType.Prism
                    )
                    {
                        white = PlayerModelFactory.CreateUserPlayer(context, config.White.Name);
                        black = PlayerModelFactory.CreateUserPlayer(context, config.Black.Name);

                    }
                    else
                    {
                        throw new ArgumentException(
                            $"{config.White.Name} vs ${config.Black.Name}" +
                            $" isn't a valid UserVsUser Configuration"
                        );
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid game mode.", nameof(config.Mode));
            }

            if (white == null || black == null)
                throw new Exception("Game configuration failed.");

            var session = new SessionModel
            {
                CreatedAt = DateTime.Now.ToUniversalTime()
            };

            // Save the session to the database
            this.context.Sessions.Add(session);
            this.context.SaveChanges();

            var board = new BoardModel
            {
                SessionId = session.Id,
                WhiteId = white.Id,
                BlackId = black.Id
            };

            // Save the board to the database
            this.context.Boards.Add(board);
            this.context.SaveChanges();

            var response = new ClassicGameDto
            {
                SessionId = session.Id,
                View = new ClassicGameViewDto
                {
                    WhiteId = white.Id,
                    BlackId = black.Id,
                    BoardId = board.Id
                }
            };

            return response;
        }

        public bool DeleteClassicGame(Guid sessionId)
        {
            var sessionModel = this.context.Sessions
                .Where(session => session.Id == sessionId).FirstOrDefault();
            if (sessionModel == null) return false;
            this.context.Sessions.Remove(sessionModel);
            this.context.SaveChanges();
            return true;
        }

        public ClassicGameViewDto ViewClassicGame(Guid sessionId)
        {
            var sessionModel = this.context.Sessions
                .Where(session => session.Id == sessionId).FirstOrDefault();
            if (sessionModel == null)
            {
                throw new NullReferenceException($"{sessionId} is not found");
            }
            var boardModel = this.context.Boards
                .Where(board => board.SessionId == sessionModel.Id).First();

            var response = new ClassicGameViewDto()
            {
                WhiteId = boardModel.WhiteId,
                BlackId = boardModel.BlackId,
                BoardId = boardModel.Id
            };

            return response;
        }
    }
}
