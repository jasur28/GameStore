using GameStore.DAL.Entities;

namespace GameStore.DAL.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public IEnumerable<Comment> GetAllByGameId(Guid id);
    }
}
