using GameStore.DAL.Entities;

namespace GameStore.BLL.Models
{
	public class GenreModel
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public IEnumerable<Genre> SubGenres { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
