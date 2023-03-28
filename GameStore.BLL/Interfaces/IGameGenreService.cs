using GameStore.BLL.Models;

namespace GameStore.BLL.Interfaces
{
	public interface IGameGenreService : ICrud<GameGenreModel>
	{
        public void Delete(Guid gameId, Guid genreId);

    }
}
