using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Models
{
    public class GameGenreModel
    {
        public Guid GameId { get; set; }
        public Guid GenreId { get; set; }
        public Game Game { get; set; }
        public Genre Genre { get; set; }
    }
}
