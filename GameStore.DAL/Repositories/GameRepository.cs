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

        public async Task<IEnumerable<Game>> GetAllWithDetailsAsync()
        {
            return await dbContext.Games
                .Include(g => g.GameGenre)
                .ThenInclude(s => s.GameSubGenres).ToListAsync();
        }

        public async Task<Game> GetByIdWithDetailsAsync(int id)
        {
            return await dbContext.Games
                .Include(g => g.GameGenre)
                .ThenInclude(s => s.GameSubGenres)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
