using GameStore.DAL.Entities;

namespace GameStore.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);

        void Add(TEntity entity);

        void DeleteById(Guid id);

        void Update(TEntity entity);
    }
}
