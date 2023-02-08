using GameStore.DAL.Interfaces;
using GameStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext _gameStoreDbContext;
        private IGameRepository _gameRepository;
        private IGenreRepository _genreRepository;
        
        public UnitOfWork(GameStoreDbContext gameStoreDbContext)
        {
            _gameStoreDbContext = gameStoreDbContext;
        }
        public IGameRepository GameRepository => _gameRepository
            = _gameRepository ?? new GameRepository(_gameStoreDbContext);
        public IGenreRepository GenreRepository => _genreRepository
            = _genreRepository ?? new GenreRepository(_gameStoreDbContext);

        public async Task SaveAsync()
        {
            await _gameStoreDbContext.SaveChangesAsync();
        }
    }
}
