using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.BLL.Services;
using GameStore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;
        
        public HomeController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            if(cart!=null)
            {
                ViewBag.count=cart.Count;
            }
            if (string.IsNullOrEmpty(searchString))
            {
                return View(_gameService.GetAll());
            }
            else
            {
                return View(_gameService.GetByFilterAsync(searchString));
            }
            
        }  

        public IActionResult About()
        {
            return View("About");
        }
    }
}
