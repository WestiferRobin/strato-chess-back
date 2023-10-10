using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StratoChess.Enums;

namespace StratoChess.Models.Player.Prism
{
	public class PrismModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public PrismTemplate Template { get; set; }
    }
}

