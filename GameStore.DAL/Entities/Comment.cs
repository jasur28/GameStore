using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ParentId { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public ApplicationUser User { get; set; }
        public Game Game { get; set; }

    }
}
