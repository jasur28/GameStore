using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;

        public HomeController(IGameService gameService, IGenreService genreService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            var gameGenres = this.genreService.GetAll();

            var genreList = new List<SelectListItem>();
            foreach (var genre in gameGenres)
            {
                genreList.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
            }

            model.FilterGenres = genreList;
            model.Games = gameService.GetAll().ToList();//?

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel postModel)
        {
            var searchString = postModel.FilterString;
            var selectedGenres = postModel.FilterGenres.Where(s => s.Selected).Select(s =>
            {
                Guid result;
                Guid.TryParse(s.Value, out result);
                return result;
            }).ToList();
            var filteredGames = gameService.GetByFilterAsync(searchString, selectedGenres).ToList();

            postModel.Games = filteredGames;

            return View("Index", postModel);

        }

        public IActionResult About()
        {
            return View("About");
        }
    }
}
