using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.BLL.Services;
using GameStore.DAL.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.ViewModel
{
    public class GameViewModel : GameModel
    {
        internal IList<SelectListItem> genreList;
        public IGenreService genreService;
        public GameViewModel(IGenreService genreService)
        {
            this.genreService = genreService;
            var gameGenres = genreService.GetAll();

            genreList = new List<SelectListItem>();
            foreach (var genre in gameGenres)
            {
                genreList.Add(new SelectListItem(genre.Name, genre.Name,
                    this.GameGenres.Any(r=>r.GenreId == genre.Id)));
            }
        }
    }
}
