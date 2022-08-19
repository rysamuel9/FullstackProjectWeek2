using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //private readonly IUser _user;

        //public AccountController(IUser user)
        //{
        //    _user = user;
        //}

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    TempData["success"] = $"Register Successfully, Youre Logged In";
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    TempData["success"] = $"Login Successfully";
                    return RedirectToAction("Index", "Home");
                }

                TempData["error"] = $"Login Failed";
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["success"] = $"Youre Logged Out";
            return RedirectToAction("Index", "Home");
        }

        //[AllowAnonymous]
        //public IActionResult Login(string? returnUrl)
        //{
        //    if (!string.IsNullOrEmpty(returnUrl))
        //    {
        //        ViewBag.returnUrl = returnUrl;
        //    }

        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login(UserViewModel model, string? returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _user.Authenticate(model.Username, model.Password);
        //        if (result.S)
        //        {
        //            if (!string.IsNullOrEmpty(returnUrl))
        //            {
        //                return LocalRedirect(returnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        ModelState.AddModelError(string.Empty, "Invalid login attempt");
        //    }
        //    return View(model);
        //}
    }
}
