using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Data;
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

        public void Add(GameModel model)
        {

            var item = mapper.Map<Game>(model);
            unitOfWork.GameRepository.Add(item);
            unitOfWork.SaveAsync();
        }

        public void Delete(Guid id)
        {
            unitOfWork.GameRepository.DeleteById(id);
            unitOfWork.SaveAsync();
        }

        public IEnumerable<GameModel> GetAll()
        {
            var items = unitOfWork.GameRepository.GetAll();
            return mapper.Map<IEnumerable<GameModel>>(items);
        }

        public IEnumerable<GameModel> GetByFilterAsync(string filterSearch)
        {
            var items = unitOfWork.GameRepository.GetAllWithDetails();

            var result = from search in items where search.Name.StartsWith(filterSearch)
                         select search;

            return mapper.Map<IEnumerable<GameModel>>(result);

        }

        public GameModel GetById(Guid id)
        {
            var item = unitOfWork.GameRepository.GetByIdWithDetails(id);
            return mapper.Map<GameModel>(item);
        }

        public void Update(GameModel model)
        {
            unitOfWork.GameRepository.Update(mapper.Map<Game>(model));
            unitOfWork.SaveAsync();
        }
    }
}
