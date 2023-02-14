using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        public GameController(IGameService gameService, IGenreService genreService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
        }
        //Get: Game/Create
        public IActionResult Create()
        {
            GameViewModel genres = new GameViewModel(genreService);
            ViewBag.Genres = genres.genreList;
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GameModel item)
        {
            //Create Guid
            item.Id = Guid.NewGuid();

            //Select Genres
            GameViewModel genres = new GameViewModel(genreService);
            ViewBag.Genres = genres.genreList;
            string[] gameGenres = Request.Form["lstGenres"].ToString().Split(",");
            List<GameGenreModel> gameGenreModel = new List<GameGenreModel>();
            foreach (string id in gameGenres)
            {
                gameGenreModel.Add(new GameGenreModel
                {
                    GameId = item.Id,
                    GenreId = new Guid(id)
                });

                //if (!string.IsNullOrEmpty(id))
                //{
                //    string name = ((List<SelectListItem>)ViewBag.Genres)
                //        .Where(x => x.Value == id).FirstOrDefault().Text;
                //}
            }
            item.GameGenres = gameGenreModel;

            //Upload Image
            var contextForm = Request.Form.Files;
            if (contextForm != null && contextForm.Count > 0)
            {
                var formFile = contextForm[0];

                if (formFile.Length > 0)
                {
                    using (var inputStream = new MemoryStream())
                    {
                        formFile.CopyTo(inputStream);
                        item.PhotoFileName = formFile.FileName;
                        item.Photo = inputStream.ToArray();
                    }
                }
            }
            else
            {
                //Default data FileStream
            }

            ModelState.ClearValidationState(nameof(GameModel));
            if (!TryValidateModel(item, nameof(GameModel)))
            {
                gameService.Add(item);
                TempData["Success"] = "The game has been created!";
                return RedirectToAction("Index", "Home");
            }
            return View(item);
        }

        // POST: Game/Details/Id
        public IActionResult Details(Guid id)
        {
            var item = gameService.GetById(id);
            
            return View(item);
        }

        // GET /Game/Edit/Id
        public IActionResult Edit(Guid id)
        {
            var item = gameService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Game/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GameModel item)
        {
            var contextForm = Request.Form.Files;
            if (contextForm != null && contextForm.Count > 0)
            {
                var formFile = contextForm[0];

                if (formFile.Length > 0)
                {
                    using (var inputStream = new MemoryStream())
                    {
                        formFile.CopyTo(inputStream);
                        item.PhotoFileName = formFile.FileName;
                        item.Photo = inputStream.ToArray();
                    }
                }
            }

            ModelState.ClearValidationState(nameof(GameModel));
            if (!TryValidateModel(item, nameof(GameModel)))
            {
                gameService.Update(item);
                TempData["Success"] = "The game has been updated!";
                return RedirectToAction("Index", "Home");
            }
            return View(item);
        }

        // GET /Game/Delete/ID
        public IActionResult Delete(Guid id)
        {
            var item = gameService.GetById(id);
            if (item == null)
            {
                TempData["Error"] = "The game does not exist!";
            }
            else
            {
                gameService.Delete(item.Id);
                TempData["Success"] = "The game has been deleted!";
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
