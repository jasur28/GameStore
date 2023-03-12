﻿using GameStore.DAL.Entities;
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
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid? ParentId { get; set; }
        public Comment? Parent { get; set; }
        public IEnumerable<Comment>? Children { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}