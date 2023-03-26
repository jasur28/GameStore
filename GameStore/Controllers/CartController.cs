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
            RoleManager<IdentityRole> roleManager, IGameService gameService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var cart = GetCartFromSession();

            return View(cart);
        }

        public IActionResult Buy(Guid id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var game = _gameService.GetById(id);

            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            if (cart == null)
            {
                cart = new List<CartModel>
                {
                      new CartModel { Game = game, Quantity = 0 }
                };

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

            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            int index = cart.FindIndex(w => w.Game.Id == id);

            cart.RemoveAt(index);

            HttpContext.Session.Set<List<CartModel>>("cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Add(Guid id)
        {
            var cart = HttpContext.Session.Get<List<CartModel>>("cart");

            int index = cart.FindIndex(w => w.Game.Id == id);

            cart[index].Quantity++;

            HttpContext.Session.Set<List<CartModel>>("cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Minus(Guid id)
        {
            // TODO: 1, 2, 3

            // 1) if you return the List please name variables in the plural, since the slightly ambiguous "cart"

            // 2) it seems not entirely logical to create a new CardModel for each game
            // instead you could create one CardModel with Dictionary<GameModel, int> to locate here Quantity
            // and game or even just Dictionary<Guid, int> for GameId and Quantity not to overload session memory

            // 3) try to use LINQ expressions and simplify this logic 
            // for instance:
            // var cart = carts.FirstOrDefault(x => x.Game.Id == id);
            // if (cart is null) return View("Index");
            //
            // if (cart.Quantity == 1)
            //   cart.Remove(t);
            // else
            //   cart.Quantity--;
            // but consider the second point in this case

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
            var cart = GetCartFromSession();

            return View(cart);
        }

        public List<CartModel> GetCartFromSession()
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

            return cart;
        }
    }
}
