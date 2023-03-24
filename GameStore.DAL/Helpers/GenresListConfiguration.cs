using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
/*public string Name { get; set; }
        public Guid? ParenId { get; set; }
        public IEnumerable<Genre> SubGenres { get; set; }*/