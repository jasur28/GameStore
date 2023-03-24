using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.BLL.Services;
using GameStore.DAL.Entities;
using GameStore.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IGameService _gameService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CartController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager, IGameService gameService )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");
            if (cart != null)
            {
                ViewBag.total = cart.Sum(s => s.Quantity * s.Game.Price);
                ViewBag.count = cart.Count();
            }
            else
            {
                cart = new List<CartModel>();
                ViewBag.total = 0;
                ViewBag.count = 0;
            }

            return View(cart);
        }

        public IActionResult Buy(Guid id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if(userId==null)
            {
                return RedirectToAction("Login", "Account");
            }
            var game = _gameService.GetById(id);
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            if (cart == null) 
            {
                cart = new List<CartModel>();
                cart.Add(new CartModel { Game = game, Quantity = 1 });
            }
            else
            {
                int index = cart.FindIndex(w => w.Game.Id == id);

                if (index != -1) 
                {
                    cart[index].Quantity++; 
                }
                else
                {
                    cart.Add(new CartModel { Game = game, Quantity = 1 });
                }
            }
        
            HttpContext.Session.Set<List<CartModel>>("cart", cart);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(Guid id)
        {
            //var game = _gameService.GetById(id);
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            int index = cart.FindIndex(w => w.Game.Id == id);
            cart.RemoveAt(index);
            HttpContext.Session.Set<List<CartModel>>("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Add(Guid id)
        {
            //var game = _gameService.GetById(id);
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            int index = cart.FindIndex(w => w.Game.Id == id);
            cart[index].Quantity++;

            HttpContext.Session.Set<List<CartModel>>("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Minus(Guid id)
        {
            //var game = _gameService.GetById(id);
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");
        
            int index = cart.FindIndex(w => w.Game.Id == id);
            if (cart[index].Quantity == 1) 
            {
                cart.RemoveAt(index); 
            }
            else
            {
                cart[index].Quantity--; 
            }
        
            HttpContext.Session.Set<List<CartModel>>("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Order()
        {
            var user = _userManager.GetUserAsync(User).Result.Id;
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");
            if (cart != null)
            {
                ViewBag.total = cart.Sum(s => s.Quantity * s.Game.Price);
                ViewBag.count = cart.Count();
            }
            else
            {
                cart = new List<CartModel>();
                ViewBag.total = 0;
                ViewBag.count = 0;
            }

            return View(cart);
        }

        //public IActionResult CompletedOrder()
        //{
        //    var cart = HttpContext.Session.Get<List<CartModel>>("cart");
        //    if (cart != null)
        //    {
        //        ViewBag.total = cart.Sum(s => s.Quantity * s.Game.Price);
        //        ViewBag.count = cart.Count();
        //    }
        //    else
        //    {
        //        cart = new List<CartModel>();
        //        ViewBag.total = 0;
        //        ViewBag.count = 0;
        //    }
        //    return PartialView("_CompleteOrderPartialView",cart);
        //}
    }
}
