﻿using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public IEnumerable<Comment> GetByGameId(Guid id);
    }
}
