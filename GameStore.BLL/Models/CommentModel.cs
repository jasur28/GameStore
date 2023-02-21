using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Models
{
    public class CommentModel
    {
        public Guid ParentId { get; set; }
        public string CommentText { get; set; }
        public string UserName { get; set; }
        public string GameName { get; set; }
    }
}
