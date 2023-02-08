using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Models
{
	public class GenreModel
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public IEnumerable<Genre> SubGenres { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
