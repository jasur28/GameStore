using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System;
using System.Data.Common;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        private readonly ICommentService _commentService;
        private readonly IGameGenreService _gameGenreService;
        private readonly UserManager<ApplicationUser> _userManager;
        public GameController(IGameService gameService,
            IGenreService genreService,
            ICommentService commentService,
            IGameGenreService gameGenreService,
            UserManager<ApplicationUser> userManager)
        {
            _gameService = gameService;
            _genreService = genreService;
            _commentService = commentService;
            _gameGenreService = gameGenreService;
            _userManager = userManager;
        }

        //Get: Game/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            GameViewModel genres = new GameViewModel(_genreService);

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
            GameViewModel genres = new GameViewModel(_genreService);

            ViewBag.Genres = genres.genreList;

            string[] gameGenres = Request.Form["listGenres"].ToString().Split(",");

            List<GameGenreModel> gameGenreModel = new List<GameGenreModel>();

            foreach (string id in gameGenres)
            {
                gameGenreModel.Add(new GameGenreModel
                {
                    Id = Guid.NewGuid(),
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
                var fileStream = System.IO.File.Open("wwwroot/img/no-image.png",FileMode.Open);

                var memoryStream = new MemoryStream();

                fileStream.CopyTo(memoryStream);

                item.Photo = memoryStream.ToArray();
                item.PhotoFileName = fileStream.Name;
            }

            ModelState.ClearValidationState(nameof(GameModel));
            if (!TryValidateModel(item, nameof(GameModel)))
            {
                _gameService.Add(item);
                TempData["Success"] = "The game has been created!";
                return RedirectToAction("Index", "Home");
            }
            return View(item);
        }

        // Get: Game/Details/Id
        public IActionResult Details(Guid id)
        {
            var game = _gameService.GetById(id);

            CommentViewModel result = new CommentViewModel();

            result.Game = game;
            result.Comments = _commentService.GetAllByGameId(id).ToList();

            return View(result);
        }

        // Post: Game/Details/Id
        [HttpPost]
        public IActionResult Details(CommentViewModel commentViewModel)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

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

            _commentService.Add(model);

            return RedirectToAction("Details", new { id = commentViewModel.GameId }); 
        }

        // GET /Game/Edit/Id
        public IActionResult Edit(Guid id)
        {
            GameViewModel genres = new GameViewModel(_genreService);
            ViewBag.Genres = genres.genreList;

            var item = _gameService.GetById(id);
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
            else
            {
                var fileStream = System.IO.File.Open("wwwroot/img/no-image.png", FileMode.Open);

                var memoryStream = new MemoryStream();

                fileStream.CopyTo(memoryStream);

                item.Photo = memoryStream.ToArray();
                item.PhotoFileName = fileStream.Name;
            }

            //Remove Genres related to the Game
            var gameGenresList = _gameGenreService.GetAll().Where(x => x.GameId == item.Id);

            foreach (var gameGenre in gameGenresList)
            {
                _gameGenreService.Delete(gameGenre.GameId, gameGenre.GenreId);
            }


            //Assign Genres to the Game
            string[] gameGenres = Request.Form["listGenres"].ToString().Split(",");

            foreach (string id in gameGenres)
            {
                var temp = new GameGenreModel
                {
                    Id = Guid.NewGuid(),
                    GameId = item.Id,
                    GenreId = new Guid(id)
                };
                _gameGenreService.Add(temp);
            }

            //Check model and save in the Database
            ModelState.ClearValidationState(nameof(GameModel));

            if (!TryValidateModel(item, nameof(GameModel)))
            {
                _gameService.Update(item);
                TempData["Success"] = "The game has been updated!";
                return RedirectToAction("Index", "Home");
            }
            
            return View(item);
        }

        // GET /Game/Delete/ID
        public IActionResult Delete(Guid id)
        {
            var item = _gameService.GetById(id);

            if (item == null)
            {
                TempData["Error"] = "The game does not exist!";
            }
            else
            {
                _gameService.Delete(item.Id);
                TempData["Success"] = "The game has been deleted!";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
