using GameStore.DAL.Entities;

namespace GameStore.DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        public Game GetByIdWithDetails(Guid id);
        public IEnumerable<Game> GetAllWithDetails();
    }
}
