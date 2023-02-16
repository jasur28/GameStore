using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.BLL.Interfaces
{
    public interface IGameService : ICrud<GameModel>
    {
        IEnumerable<GameModel> GetByFilterAsync(string filterSearch);
    }
}
