using GameStore.BLL.Models;

namespace GameStore.BLL.Interfaces
{
    public interface IGameService : ICrud<GameModel>
    {
        Task<IEnumerable<GameModel>> GetByFilterAsync(FilterSearchModel filterSearch);
    }
}
