using GameStore.DAL.Data;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(GameStoreDbContext gameStoreDbContext) : base(gameStoreDbContext)
        {
        }

        public Game GetByIdWithDetails(Guid id)
        {
            return dbContext.Set<Game>().Include(r => r.GameGenres).FirstOrDefault(r => r.Id == id);
        }
    }
}
