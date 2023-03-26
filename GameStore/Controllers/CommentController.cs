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
    public class CommentController : Controller
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CommentController(IGameService gameService,
            IGenreService genreService,
            ICommentService commentService,
            UserManager<ApplicationUser> userManager)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.commentService = commentService;
            _userManager = userManager;
        }

        public IActionResult DeleteComment(Guid id)
        {
            var comment = commentService.GetById(id);

            return PartialView("_DeleteCommentPartialView", comment);
        }

        [HttpPost]
        public IActionResult DeleteComment(CommentModel item)
        {
            item.UserId = _userManager.GetUserAsync(User).Result.Id;

            item.IsDeleted=true;

            ModelState.ClearValidationState(nameof(CommentModel));

            if (!TryValidateModel(item, nameof(CommentModel)))
            {
                commentService.Update(item);

                return RedirectToAction("Details", "Game", new { id = item.GameId });
            }
            return View("Index", "Home");
        }
        
        public IActionResult EditComment(Guid id)
        {
            var comment = commentService.GetById(id);

            return PartialView("_EditCommentPartialView", comment);
        }

        [HttpPost]
        public IActionResult EditComment(CommentModel item)
        {
            item.UserId = _userManager.GetUserAsync(User).Result.Id;

            ModelState.ClearValidationState(nameof(CommentModel));

            if (!TryValidateModel(item, nameof(CommentModel)))
            {
                commentService.Update(item);

                TempData["Success"] = "The comment has been updated!";

                return RedirectToAction("Details","Game", new { id = item.GameId });
            }
            return View("Index", "Home");
        }

        public IActionResult RestoreComment(Guid id)
        {
            var comment = commentService.GetById(id);

            return PartialView("_RestoreCommentPartialView", comment);
        }

        [HttpPost]
        public IActionResult RestoreComment(CommentModel item)
        {
            item.UserId = _userManager.GetUserAsync(User).Result.Id;

            item.IsDeleted = false;

            ModelState.ClearValidationState(nameof(CommentModel));

            if (!TryValidateModel(item, nameof(CommentModel)))
            {
                commentService.Update(item);

                return RedirectToAction("Details", "Game", new { id = item.GameId });
            }

            return View("Index", "Home");
        }
    }
}

