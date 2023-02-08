using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
	public class GameGenreController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
