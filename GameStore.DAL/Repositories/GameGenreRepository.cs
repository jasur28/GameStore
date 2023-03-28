using GameStore.DAL.Data;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace GameStore.DAL.Repositories
{
    public class GameGenreRepository : Repository<GameGenre>, IGameGenreRepository
    {
        public GameGenreRepository(GameStoreDbContext gameStoreDbContext) : base(gameStoreDbContext)
        {
        }

        public GameGenre GetByIdWithTwoParams(Guid gameId, Guid genreId)
        {

            return dbContext.Set<GameGenre>().Find(gameId, genreId);
        }

        public void DeleteById(Guid gameId, Guid genreId)
        {
            var item = GetByIdWithTwoParams(gameId, genreId);
            dbContext.Set<GameGenre>().Remove(item);
        }
    }
}
