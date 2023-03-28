using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public class Game : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        public string PhotoFileName { get; set; }
        public byte[] Photo { get; set; }
        public IEnumerable<GameGenre>? GameGenres { get; set; }
        public IEnumerable<Comment>? GameComments { get; set; }
    }
}
