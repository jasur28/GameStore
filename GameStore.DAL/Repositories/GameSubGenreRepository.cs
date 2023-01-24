using GameStore.DAL.Data;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;

namespace GameStore.DAL.Repositories
{
    public class GameSubGenreRepository : Repository<GameSubGenre>, IGameSubGenreRepository
    {
        public GameSubGenreRepository(GameStoreDbContext gameStoreDbContext) : base(gameStoreDbContext)
        {
        }
    }
}
