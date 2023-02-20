using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using Microsoft.AspNetCore.Mvc;

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

            genreList = new List<SelectListItem>();
            foreach (var genre in gameGenres)
            {
                genreList.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
            }

            model.FilterGenres = genreList;
            model.Games = gameService.GetAll();

            return View("Index", postModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel postModel)
        {
            var searchString = postModel.FilterString;
            var selectedGenres = postModel.FilterGenres.Where(s => s.Selected).Select(s => s.Value).ToList();
            var filteredGames = gameService.Get(searchString, selectedGenres);

            postModel.Games = filteredGames;

            return View("Index", postModel);

        }

        public IActionResult About()
        {
            return View("About");
        }
    }
}
