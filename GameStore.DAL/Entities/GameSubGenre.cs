namespace GameStore.DAL.Entities
{
    public class GameSubGenre : BaseEntity
    {
        public string Name { get; set; }
        public Guid GameGenreId { get; set; }
        public GameGenre GameGenre { get; set; }
    }
}
