using GameStore.DAL.Entities;

namespace GameStore.BLL.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoFileName { get; set; }
        public byte[] Photo { get; set; }
        public IEnumerable<GameGenre> GameGenres { get; set; }
    }
}
