using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.ViewModel
{
    public class GameViewModel : GameModel
    {
        internal IList<SelectListItem> genreList;
        private IGenreService genreService;
        public GameViewModel(IGenreService genreService)
        {
            this.genreService = genreService;
            var gameGenres = this.genreService.GetAll();

            genreList = new List<SelectListItem>();
            foreach (var genre in gameGenres)
            {
                genreList.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
            }
        }
    }
}
