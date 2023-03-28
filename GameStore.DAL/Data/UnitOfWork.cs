using GameStore.DAL.Interfaces;
using GameStore.DAL.Repositories;

namespace GameStore.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext _gameStoreDbContext;
        private IGameRepository _gameRepository;
        private IGenreRepository _genreRepository;
        private ICommentRepository _commentRepository;
        private IGameGenreRepository _gameGenreRepository;

        public UnitOfWork(GameStoreDbContext gameStoreDbContext)
        {
            _gameStoreDbContext = gameStoreDbContext;
        }
        public IGameRepository GameRepository => _gameRepository
            = _gameRepository ?? new GameRepository(_gameStoreDbContext);
        public IGameGenreRepository GameGenreRepository => _gameGenreRepository
            = _gameGenreRepository ?? new GameGenreRepository(_gameStoreDbContext);
        public ICommentRepository CommentRepository => _commentRepository
            = _commentRepository ?? new CommentRepository(_gameStoreDbContext);
        public IGenreRepository GenreRepository => _genreRepository
            = _genreRepository ?? new GenreRepository(_gameStoreDbContext);

        public async Task SaveAsync()
        {
            await _gameStoreDbContext.SaveChangesAsync();
        }
    }
}
