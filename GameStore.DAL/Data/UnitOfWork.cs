using GameStore.DAL.Interfaces;
using GameStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext _gameStoreDbContext;
        private IGameRepository _gameRepository;
        private IGameGenreRepository _gameGenreRepository;
        private IGameSubGenreRepository _gameSubGenreRepository;
        public UnitOfWork(GameStoreDbContext gameStoreDbContext)
        {
            _gameStoreDbContext = gameStoreDbContext;
        }
        public IGameRepository GameRepository => _gameRepository
            = _gameRepository ?? new GameRepository(_gameStoreDbContext);
        public IGameGenreRepository GameGenreRepository => _gameGenreRepository
            = _gameGenreRepository ?? new GameGenreRepository(_gameStoreDbContext);
        public IGameSubGenreRepository GameSubGenreRepository => _gameSubGenreRepository
            = _gameSubGenreRepository ?? new GameSubGenreRepository(_gameStoreDbContext);

        public async Task SaveAsync()
        {
            await _gameStoreDbContext.SaveChangesAsync();
        }
    }
}
