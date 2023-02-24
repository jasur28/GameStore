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
	public class CommentService : ICrud<CommentModel>, ICommentService
	{
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void Add(CommentModel model)
		{
            var item = mapper.Map<Game>(model);
            unitOfWork.GameRepository.Add(item);
            unitOfWork.SaveAsync();
            throw new NotImplementedException();
		}

		public void Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CommentModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public CommentModel GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public void Update(CommentModel model)
		{
			throw new NotImplementedException();
		}
	}
}
