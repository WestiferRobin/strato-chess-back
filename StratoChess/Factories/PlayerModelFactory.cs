using System;
using Microsoft.EntityFrameworkCore;
using StratoChess.Converter;
using StratoChess.Data;
using StratoChess.Enums;
using StratoChess.Models;
using StratoChess.Models.Player;
using StratoChess.Models.Player.User;

namespace StratoChess.Factories
{
	public static class PlayerModelFactory
	{
        public static PlayerModel CreateUserPlayer(StratoChessDbContext context, string name)
        {
            var userModel = context.Users
                .Where(user => user.Username == name)
                .First();
            var userPlayer = context.Players
                .OfType<UserPlayer>()
                .Where(player => player.UserId == userModel.Id)
                .First();
            return userPlayer;
        }

        public static PlayerModel CreatePrismPlayer(StratoChessDbContext context, string name)
        {
            PrismTemplate template = PrismConverter.ConvertStringToTemplate(name);
            var prismModel = context.Prisms
                .Where(prism => prism.Template == template)
                .First();
            var prismPlayer = context.Players
                .OfType<PrismPlayer>()
                .Where(player => player.PrismId == prismModel.Id)
                .First();
            return prismPlayer;
        }
    }
}

