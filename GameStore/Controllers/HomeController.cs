using GameStore.BLL.Interfaces;
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
        public async Task<IActionResult> Index()
        {
            return Ok(await gameService.GetAllAsync());
        }
    }
}
