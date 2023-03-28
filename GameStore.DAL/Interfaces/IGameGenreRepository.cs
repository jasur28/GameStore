using GameStore.DAL.Entities;

namespace GameStore.DAL.Interfaces
{
    public interface IGameGenreRepository : IRepository<GameGenre>
    {
        public GameGenre GetByIdWithTwoParams(Guid gameId, Guid genreId);
        public void DeleteById(Guid gameId, Guid genreId);
    }
}
