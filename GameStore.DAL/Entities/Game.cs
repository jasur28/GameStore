namespace GameStore.DAL.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public ICollection<GameGenre> GameGenre { get; set; }
    }
}
