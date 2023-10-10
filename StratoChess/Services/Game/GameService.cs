using System;
using System.Linq;
using StratoChess.Data;
using StratoChess.DTOs.Game;
using StratoChess.Enums;
using StratoChess.Models;
using StratoChess.Models.Player;
using StratoChess.Models.Player.Prism;
using StratoChess.Models.Player.User;

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
                    var whiteUser = this.context.Users.FirstOrDefault(user => user.Username == config.White.Name);
                    var asdf = Enum.GetName(typeof(PrismTemplate), PrismTemplate.Alpha);
                    var blackPrism = this.context.Prisms.FirstOrDefault(prism =>
                        Enum.GetName(typeof(PrismTemplate), prism.Template) == config.Black.Name);

                    if (whiteUser != null && blackPrism != null)
                    {
                        white = new UserPlayer
                        {
                            UserId = whiteUser.Id,
                            Name = whiteUser.Username,
                            PlayerRank = 800,
                            Theme = new PlayerTheme
                            {
                                PrimaryColor = "#fff",
                                SecondaryColor = "#000"
                            }
                        };

                        black = new PrismPlayer
                        {
                            PrismId = blackPrism.Id,
                            Name = whiteUser.Username, // You might want to update this
                            PlayerRank = 800,
                            Theme = new PlayerTheme
                            {
                                PrimaryColor = "#000",
                                SecondaryColor = "#fff"
                            }
                        };
                    }
                    else
                    {
                        throw new Exception("User or Prism not found.");
                    }
                    break;
                case ClassicGameMode.PrismVsPrism:
                    throw new NotImplementedException("PrismVsPrism");
                case ClassicGameMode.UserVsUser:
                    throw new NotImplementedException("UserVsUser");
                default:
                    throw new ArgumentException("Invalid game mode.", nameof(config.Mode));
            }

            if (white != null && black != null)
            {
                var board = new BoardModel
                {
                    WhiteId = white.Id,
                    BlackId = black.Id
                };

                var session = new SessionModel
                {
                    CreatedAt = DateTime.Now
                };

                this.context.Players.AddRange(white, black);
                this.context.Boards.Add(board);
                this.context.Sessions.Add(session);

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

            throw new Exception("Game configuration failed.");
        }

        public bool DeleteClassicGame(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public ClassicGameViewDto ViewClassicGame(Guid sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
