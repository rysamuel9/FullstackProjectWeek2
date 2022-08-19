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
                    TempData["success"] = $"Register Successfully";
                    TempData["success"] = $"Youre Logged In";
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
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
