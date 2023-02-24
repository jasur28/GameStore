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
            var item = mapper.Map<Comment>(model);
            unitOfWork.CommentRepository.Add(item);
            unitOfWork.SaveAsync();
		}

		public void Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CommentModel> GetAll()
		{
            throw new NotImplementedException();
        }

		public IEnumerable<CommentModel> GetAllByGameId(Guid id)
		{
			var items = unitOfWork.CommentRepository.GetAllByGameId(id);
            return mapper.Map<IEnumerable<CommentModel>>(items);
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
