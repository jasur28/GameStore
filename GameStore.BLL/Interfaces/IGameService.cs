using GameStore.BLL.Models;

namespace GameStore.BLL.Interfaces
{
    public interface IGameService : ICrud<GameModel>
    {
        IEnumerable<GameModel> GetByFilterAsync(string filterSearch);
    }
}
