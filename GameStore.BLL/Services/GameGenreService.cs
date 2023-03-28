using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;


namespace GameStore.BLL.Services
{
	public class GameGenreService : IGameGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameGenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(GameGenreModel model)
		{
            var item = _mapper.Map<GameGenre>(model);
            _unitOfWork.GameGenreRepository.Add(item);
            _unitOfWork.SaveAsync();
        }

		public void Delete(Guid id)
		{
            _unitOfWork.GameGenreRepository.DeleteById(id);
            _unitOfWork.SaveAsync();
        }

		public void Delete(Guid gameId, Guid genreId)
		{
            _unitOfWork.GameGenreRepository.DeleteById(gameId, genreId);
            _unitOfWork.SaveAsync();
        }

		public IEnumerable<GameGenreModel> GetAll()
		{
            var items = _unitOfWork.GameGenreRepository.GetAll();
            return _mapper.Map<IEnumerable<GameGenreModel>>(items);
        }

		public GameGenreModel GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public void Update(GameGenreModel model)
		{
			throw new NotImplementedException();
		}
	}
}
