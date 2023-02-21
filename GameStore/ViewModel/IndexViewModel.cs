using GameStore.BLL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.ViewModel
{
    public class IndexViewModel
    {
        public List<SelectListItem> FilterGenres { get; set; }
        public string FilterString { get; set; }
        public List<GameModel> Games { get; set; }
    }
}
