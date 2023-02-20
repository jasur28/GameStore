using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.ViewModel
{
    public class IndexViewModel
    {
        public List<SelectListItems> FilterGenres { get; set; }
        public string FilterString { get; set; }

        public List<GameModel> Games { get; set; }
    }
}
