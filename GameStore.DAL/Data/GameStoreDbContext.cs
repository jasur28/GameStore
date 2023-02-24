using GameStore.DAL.Entities;
using GameStore.DAL.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Data
{
    public class GameStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options): base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<GameGenre>().HasKey(gg => new { gg.GameId, gg.GenreId });
            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Game)
                .WithMany(gg=>gg.GameGenres).HasForeignKey(k=>k.GameId);
            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Genre)
                .WithMany(gg => gg.GameGenres).HasForeignKey(k => k.GenreId);

            base.OnModelCreating(modelBuilder);


        }
    }
}
