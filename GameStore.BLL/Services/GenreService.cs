using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Interfaces;
// TODO: there are a lot of unused namespaces, please keep it clean
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class GenreService : ICrud<GenreModel>, IGenreService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
            var items = unitOfWork.GenreRepository.GetAll();
            return mapper.Map<IEnumerable<GenreModel>>(items);
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
