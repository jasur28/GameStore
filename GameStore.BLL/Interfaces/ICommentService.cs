using GameStore.BLL.Models;

namespace GameStore.BLL.Interfaces
{
	public interface ICommentService : ICrud<CommentModel>
	{
		IEnumerable<CommentModel> GetAllByGameId(Guid id);
	}
}
