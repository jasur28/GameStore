using GameStore.BLL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.ViewModel
{
    public class GameGenreViewModel 
    {
        public IEnumerable<GameModel>? Games { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public string? GameGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
