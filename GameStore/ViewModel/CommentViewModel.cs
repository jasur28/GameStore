using GameStore.BLL.Models;

namespace GameStore.ViewModel
{
	public class CommentViewModel 
	{
		public GameModel Game { get; set; }
		public List<CommentModel> Comment { get; set; }
	}
}
