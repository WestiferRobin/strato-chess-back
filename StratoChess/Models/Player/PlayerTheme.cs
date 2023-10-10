
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StratoChess.Models
{
	public class PlayerTheme
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
        public string PrimaryColor { get; set; }

		[Required]
		public string SecondaryColor { get; set; }
	}
}

