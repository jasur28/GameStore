using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class GameService : ICrud<GameModel>, IGameService
    {
        public Task AddAsync(GameModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameModel>> GetByFilterAsync(FilterSearchModel filterSearch)
        {
            throw new NotImplementedException();
        }

        public Task<GameModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GameModel model)
        {
            throw new NotImplementedException();
        }
    }
}
