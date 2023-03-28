namespace GameStore.DAL.Entities
{
	public class Genre : BaseEntity
	{
        public string Name { get; set; }
        public Guid? ParenId { get; set; }
        public IEnumerable<Genre> SubGenres { get; set; }
        public IEnumerable<GameGenre> GameGenres { get; set; }

    }
}
