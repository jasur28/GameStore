using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;

namespace GameStore.BLL.Services
{
    public class GameService : ICrud<GameModel>, IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(GameModel model)
        {

            var item = _mapper.Map<Game>(model);
            _unitOfWork.GameRepository.Add(item);
            _unitOfWork.SaveAsync();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GameRepository.DeleteById(id);
            _unitOfWork.SaveAsync();
        }

        public IEnumerable<GameModel> GetAll()
        {
            var items = _unitOfWork.GameRepository.GetAll();
            return _mapper.Map<IEnumerable<GameModel>>(items);
        }

        public IEnumerable<GameModel> GetByFilterAsync(string filterSearch)
        {
            var items = _unitOfWork.GameRepository.GetAllWithDetails();

            var result = from search in items where search.Name.StartsWith(filterSearch)
                         select search;

            return _mapper.Map<IEnumerable<GameModel>>(result);

        }

        public GameModel GetById(Guid id)
        {
            var item = _unitOfWork.GameRepository.GetByIdWithDetails(id);
            return _mapper.Map<GameModel>(item);
        }

        public void Update(GameModel model)
        {
            _unitOfWork.GameRepository.Update(_mapper.Map<Game>(model));
            _unitOfWork.SaveAsync();
        }
    }
}
