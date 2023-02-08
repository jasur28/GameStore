using GameStore.DAL.Data;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly GameStoreDbContext dbContext;
        public Repository(GameStoreDbContext gameStoreDbContext)
        {
            dbContext = gameStoreDbContext;
        }
        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void DeleteById(Guid id)
        {
            var item = GetById(id);
            dbContext.Set<TEntity>().Remove(item);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
    }
}
