﻿using GameStore.DAL.Data;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreDbContext gameStoreDbContext) : base(gameStoreDbContext)
        {
        }

        public IEnumerable<Comment> GetAllByGameId(Guid id)
        {
            return dbContext.Set<Comment>()
                .Include(u=>u.User)
                .Include(c=>c.Children)
                .ThenInclude(u=>u.User)
                .Where(g=>g.GameId==id)
                .OrderBy(x => x.CommentDate);
        }
    }
}
