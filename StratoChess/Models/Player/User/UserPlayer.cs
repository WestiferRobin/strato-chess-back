using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StratoChess.Models.Player.User
{
    public class UserPlayer : PlayerModel
    {
        [Required]
        public required Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserModel User { get; set; }
    }
}

