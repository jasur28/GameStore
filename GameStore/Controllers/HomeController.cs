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
        public IActionResult Index(string searchString)//, list
        {
            if(string.IsNullOrEmpty(searchString))
            {
                return View(gameService.GetAll());
            }
            else
            {
                return View(gameService.GetByFilterAsync(searchString));
            }
            
        }  

        public IActionResult About()
        {
            return View("About");
        }
    }
}
