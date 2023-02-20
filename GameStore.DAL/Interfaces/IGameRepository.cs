using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        public Game GetByIdWithDetails(Guid id);
        public IEnumerable<Game> GetAllWithDetails();

        public IEnumerable<Game> Get(string filterSearch, List<Guid> filteredGenres);
    }
}
