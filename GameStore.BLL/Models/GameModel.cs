namespace GameStore.BLL.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public ICollection<int> GameGenreIds { get; set; }
    }
}
