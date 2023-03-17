using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
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

            if (cart == null) //no item in the cart
            {
                cart = new List<CartModel>();
                cart.Add(new CartModel { Game = game, Quantity = 1 });
            }
            else
            {
                int index = cart.FindIndex(w => w.Game.Id == id);

                if (index != -1) //if item already in the 
                {
                    cart[index].Quantity++; //increment by 1
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
            var game = _gameService.GetById(id);
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            int index = cart.FindIndex(w => w.Game.Id == id);
            cart.RemoveAt(index);
            HttpContext.Session.Set<List<CartModel>>("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Add(Guid id)
        {
            var game = _gameService.GetById(id);
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            int index = cart.FindIndex(w => w.Game.Id == id);
            cart[index].Quantity++; //increment by 1

            HttpContext.Session.Set<List<CartModel>>("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Minus(Guid id)
        {
            var game = _gameService.GetById(id);
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");
        
            int index = cart.FindIndex(w => w.Game.Id == id);
            if (cart[index].Quantity == 1) //last item of a product
            {
                cart.RemoveAt(index); //remove it
            }
            else
            {
                cart[index].Quantity--; //reduce by 1
            }
        
            HttpContext.Session.Set<List<CartModel>>("cart", cart);
            return RedirectToAction("Index");
        }
    }
}
