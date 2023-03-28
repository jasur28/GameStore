using GameStore.BLL.Interfaces;
using GameStore.DAL.Entities;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICommentService _commentService;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICommentService commentService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _commentService = commentService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid) return View();

            var newUser = new ApplicationUser
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.EmailAddress,
                UserName = register.UserName,
                PasswordHash = register.Password
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            TempData["Success"] = "The accoount has been created!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Login or Password Incorrect");

            return View(loginModel);
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Remove("cart");

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Profile()
        {

            var userId = _userManager.GetUserId(HttpContext.User);
            var comments = _commentService.GetAll().Where(u => u.UserId == userId).Where(c => c.IsDeleted == true);
            var user = _userManager.FindByIdAsync(userId).Result;

            var profileViewModel = new ProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                ProfilePicture = user.ProfilePicture,
                Email = user.Email,
                Comments = comments.ToList()
            };

            return View(profileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel profileViewModel)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _userManager.FindByIdAsync(userId).Result;

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
                        profileViewModel.PhotoFileName = formFile.FileName;
                        profileViewModel.ProfilePicture = inputStream.ToArray();
                    }
                }
            }

            user.FirstName = profileViewModel.FirstName;
            user.LastName = profileViewModel.LastName;
            user.UserName = profileViewModel.Username;
            user.PhotoFileName = profileViewModel.PhotoFileName;
            user.ProfilePicture = profileViewModel.ProfilePicture;
            user.Email = profileViewModel.Email;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(profileViewModel);
        }
    }
}
