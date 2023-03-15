using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public GameController(IGameService gameService,
            IGenreService genreService,
            ICommentService commentService,
            UserManager<ApplicationUser> userManager)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.commentService = commentService;
            _userManager = userManager;
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
            string[] gameGenres = Request.Form["listGenres"].ToString().Split(",");
            List<GameGenreModel> gameGenreModel = new List<GameGenreModel>();
            foreach (string id in gameGenres)
            {
                gameGenreModel.Add(new GameGenreModel
                {
                    GameId = item.Id,
                    GenreId = new Guid(id)
                });
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

        // Get: Game/Details/Id
        public IActionResult Details(Guid id)
        {
            var game = gameService.GetById(id);
            CommentViewModel result = new CommentViewModel();
            result.Game = game;
            result.Comments = commentService.GetAllByGameId(id).ToList();

            return View(result);
        }
        // Post: Game/Details/Id
        [HttpPost]
        public IActionResult Details(CommentViewModel commentViewModel)
        {
            CommentModel model = new CommentModel();
            model.Id = Guid.NewGuid();
            model.GameId = commentViewModel.GameId;
            model.UserId = _userManager.GetUserAsync(User).Result.Id;
            model.CommentText = commentViewModel.CommentText;
            model.CommentDate = DateTime.Now;
            if (commentViewModel.PostType == "reply")
            {
                model.ParentId = commentViewModel.ParentId;
            }
            commentService.Add(model);

            return RedirectToAction("Details", new { id = commentViewModel.GameId }); 
        }

        // GET /Game/Edit/Id
        public IActionResult Edit(Guid id)
        {
            GameViewModel genres = new GameViewModel(genreService);
            ViewBag.Genres = genres.genreList;

            var item = gameService.GetById(id);
            genres.Id = item.Id;
            genres.Name = item.Name;
            genres.Description = item.Description;
            genres.Price = item.Price;
            genres.GameGenres = item.GameGenres;
            genres.Photo = item.Photo;
            genres.PhotoFileName = item.PhotoFileName;
            if (genres == null)
            {
                return NotFound();
            }

            return View(genres);
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

            //Select Genres
            GameViewModel genres = new GameViewModel(genreService);
            ViewBag.Genres = genres.genreList;
            string[] gameGenres = Request.Form["listGenres"].ToString().Split(",");
            List<GameGenreModel> gameGenreModel = new List<GameGenreModel>();
            foreach (string id in gameGenres)
            {
                gameGenreModel.Add(new GameGenreModel
                {
                    GameId = item.Id,
                    GenreId = new Guid(id)
                });
            }
            item.GameGenres = gameGenreModel;
            
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
