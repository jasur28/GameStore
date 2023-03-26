using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Interfaces;

namespace GameStore.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(GenreModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GenreModel> GetAll()
        {
            var items = _unitOfWork.GenreRepository.GetAll();
            return _mapper.Map<IEnumerable<GenreModel>>(items);
        }

        public GenreModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(GenreModel model)
        {
            throw new NotImplementedException();
        }
    }
}
