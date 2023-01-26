using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class GameService : ICrud<GameModel>, IGameService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task AddAsync(GameModel model)
        {
            var item = mapper.Map<Game>(model);
            unitOfWork.GameRepository.AddAsync(item);
            return unitOfWork.SaveAsync();
        }

        public Task DeleteAsync(int id)
        {
            var item = unitOfWork.GameRepository.DeleteByIdAsync(id);
            return unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<GameModel>> GetAllAsync()
        {
            var items = await unitOfWork.GameRepository.GetAllAsync();
            return mapper.Map<IEnumerable<GameModel>>(items);
        }

        public Task<IEnumerable<GameModel>> GetByFilterAsync(FilterSearchModel filterSearch)
        {
            throw new NotImplementedException();
        }

        public Task<GameModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GameModel model)
        {
            throw new NotImplementedException();
        }
    }
}
