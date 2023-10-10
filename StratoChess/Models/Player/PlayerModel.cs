using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StratoChess.Models
{
    public class PlayerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public long PlayerRank { get; set; }

        [Required]
        public Guid ThemeId { get; set; }
        [ForeignKey(nameof(ThemeId))]
        public PlayerTheme Theme { get; set; }
    }
}
