using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.BLL.Interfaces
{
    public interface IGameService : ICrud<GameModel>
    {
        Task<IEnumerable<GameModel>> GetByFilterAsync(FilterSearchModel filterSearch);
    }
}
