using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StratoChess.Models.Player.Prism;

namespace StratoChess.Models.Player
{
    public class PrismPlayer : PlayerModel
    {
        [Required]
        public required Guid PrismId { get; set; }
        [ForeignKey(nameof(PrismId))]
        public PrismModel Prism { get; set; }
    }
}

