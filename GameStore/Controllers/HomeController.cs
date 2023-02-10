using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService gameService;
        
        public HomeController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(gameService.GetAll());
        }

        public IActionResult About()
        {
            return View("About");
        }
    }
}
//upload image
//download image
//generic template for view include AJAX fucntion