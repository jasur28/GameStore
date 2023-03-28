using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GameStore.DAL.Entities;

namespace GameStore.DAL.Helpers
{
	public class GenresListConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Strategy"
            },
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Rpg"
            },
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Sports"
            },
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Races"
            },
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Action"
            },
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Adventure"
            },
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Puzzle & Skill"
            },
            new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Others"
            });
        }
    }
}
