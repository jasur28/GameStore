﻿using GameStore.DAL.Entities;
using GameStore.DAL.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Data
{
    public class GameStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenresListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //GameGenre
            modelBuilder.Entity<GameGenre>().HasKey(gg => new { gg.GameId, gg.GenreId });
            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Game)
                .WithMany(gg => gg.GameGenres).HasForeignKey(k => k.GameId);
            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Genre)
                .WithMany(gg => gg.GameGenres).HasForeignKey(k => k.GenreId);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserComments)
                .HasForeignKey(x => x.UserId);


            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Game)
                .WithMany(x => x.GameComments)
                .HasForeignKey(x => x.GameId);

            this.SeedUserRoles(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                });
        }
    }
}
