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
            return dbContext.Set<Game>().Include(r => r.GameGenres).ThenInclude(r=>r.Genre).FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Game> GetAllWithDetails()
        {
            return dbContext.Set<Game>().Include(r => r.GameGenres).ThenInclude(r => r.Genre).ThenInclude(g=>g.SubGenres).ToList();
        }

        public IEnumerable<Game> Get(string filterSearch, List<Guid> filteredGenres)
        {
            return dbContext.Set<Game>().Include(r => r.GameGenres).Where(w => w.Name.Contains(filterSearch) && w.GameGenres.Any(a => filteredGenres.Any(ga => ga == a.GameGenreId))).ToList();
        }
    }
}
