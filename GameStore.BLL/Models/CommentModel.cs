using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Models
{
	public class CommentModel
	{
		public Guid Id { get; set; }
		public Guid GameId { get; set; }
		public Guid UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid ParentId { get; set; }
        public ApplicationUser User { get; set; }
        public Game Game { get; set; }
    }
}
