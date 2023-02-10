using GameStore.DAL.Entities;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            ApplicationUser newUser = new ApplicationUser
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
            return RedirectToAction("Index", "Home");
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginModel)//, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user != null)
            {
                var result = await
                _signInManager.PasswordSignInAsync(user, loginModel.Password, false , true);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Login or Password Incorrect");
                    return View(loginModel);
                }
            }
            
            //if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }
    }
}
