namespace GameStore.DAL.Entities
{
    public class GameGenre : BaseEntity
    {
        public string Name { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<GameSubGenre> GameSubGenres { get; set; }
    }
}
