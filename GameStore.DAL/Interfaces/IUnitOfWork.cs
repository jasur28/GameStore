using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        IGameGenreRepository GameGenreRepository { get; }
        IGameSubGenreRepository GameSubGenreRepository { get; }
        Task SaveAsync();
    }
}
