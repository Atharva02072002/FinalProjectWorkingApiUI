using FinalProject.UI.Models;
using FinalProject.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View(new LoginViewModel());
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser? user = await userManager.FindByNameAsync(loginModel.Username);
                if (user != null)
                {
                    await signInManager.SignOutAsync(); // Logout first
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded) // Delete cookie 3rd false
                    {
                        var roles = await userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home");

                        }
                        else if (roles.Contains("Receptionist"))
                        {
                            return RedirectToAction("Index1", "Home");
                        }
                        else
                        {
                            return Redirect(loginModel.ReturnUrl ?? "/");
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid name and/or password");
            }
            return View(loginModel);
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToActionResult> RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                var registeredUser = await userManager.CreateAsync(user, user.Password);
                if (registeredUser.Succeeded)
                {
                    await userManager.AddToRolesAsync(user, user.Role);
                }
                if (!registeredUser.Succeeded)
                {
                    foreach (var error in registeredUser.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                }
                return RedirectToAction("Login");
            }
            return RedirectToAction("register", user);
        }

        [HttpGet("register")]
        public ViewResult RegisterUser()
        {
            return View(new User());
        }
    }
}
