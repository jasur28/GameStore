using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;

namespace GameStore.BLL.Services
{
    public class CommentService : ICommentService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // TODO: since it's supposed to be an asynchronous method, use keyword "async"
        // and remember that returning void in async methods is very bad practice.
        // when an asynchronous method returns void:
        // 1) it means that the method doesn't produce a result that can be awaited or consumed by the caller.
        // 2) it can make it difficult to handle exceptions 
        // instead of 'void' return 'Task, Task<Result>, ValueTask, ValueTask<Result>'
        public void Add(CommentModel model)
		{
            var item = _mapper.Map<Comment>(model);
            _unitOfWork.CommentRepository.Add(item);
            // TODO: use 'await' operator in asynchronous methods since this can cause problems
            // the async operation will start executing on a separate thread,
            // but the calling thread will continue executing the next statement immediately
            // without waiting for the async operation to complete
            // await unitOfWork.SaveAsync();
            // the same problem is almost everywhere, correct it please
            _unitOfWork.SaveAsync();
		}
        // result should look like this:
        //public async Task Add(CommentModel model)
        //{
        //    var item = mapper.Map<Comment>(model);
        //    unitOfWork.CommentRepository.Add(item);
        //    await unitOfWork.SaveAsync();
        //}

        // I advise you to pay more attention to asynchronous programming,
        // in particular, the technique of canceling multithreading using CancellationToken

        public void Delete(Guid id)
		{
            throw new NotImplementedException();
        }

		public IEnumerable<CommentModel> GetAll()
		{
            var items = _unitOfWork.CommentRepository.GetAll();
            return _mapper.Map<IEnumerable<CommentModel>>(items);
        }

		public IEnumerable<CommentModel> GetAllByGameId(Guid id)
		{
			var items = _unitOfWork.CommentRepository.GetAllByGameId(id);
            return _mapper.Map<IEnumerable<CommentModel>>(items);
        }

		public CommentModel GetById(Guid id)
		{
            var item = _unitOfWork.CommentRepository.GetById(id);
            return _mapper.Map<CommentModel>(item);
        }

		public void Update(CommentModel model)
		{
            _unitOfWork.CommentRepository.Update(_mapper.Map<Comment>(model));
            _unitOfWork.SaveAsync();
        }
	}
}
