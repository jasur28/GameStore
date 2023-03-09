using GameStore.BLL.Models;

namespace GameStore.ViewModel
{
	public class CommentViewModel 
	{
		public GameModel Game { get; set; }
		public List<CommentModel> Comment { get; set; }

		public string CommentText { get; set; }
		public Guid GameId { get; set; }
		public string PostType { get; set; }
        public Guid ParentId { get; set; }
    }
}
