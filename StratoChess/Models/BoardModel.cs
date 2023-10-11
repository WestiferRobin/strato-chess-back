using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StratoChess.Models
{
    public class BoardModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid SessionId { get; set; }

        [Required]
        public string BoardData { get; set; }

        [ForeignKey(nameof(SessionId))]
        public SessionModel Session { get; set; }

        [Required]
        public Guid WhiteId { get; set; }

        [ForeignKey(nameof(WhiteId))]
        public PlayerModel White { get; set; }

        [Required]
        public Guid BlackId { get; set; }

        [ForeignKey(nameof(BlackId))]
        public PlayerModel Black { get; set; }
    }
}
