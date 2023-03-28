namespace GameStore.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        IGenreRepository GenreRepository { get; }
        ICommentRepository CommentRepository { get; }
        IGameGenreRepository GameGenreRepository { get; }
        Task SaveAsync();
    }
}
