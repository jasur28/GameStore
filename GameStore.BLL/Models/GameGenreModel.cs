using GameStore.DAL.Entities;

namespace GameStore.BLL.Models
{
    public class GameGenreModel
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid GenreId { get; set; }
        public Game Game { get; set; }
        public Genre Genre { get; set; }
    }
}
