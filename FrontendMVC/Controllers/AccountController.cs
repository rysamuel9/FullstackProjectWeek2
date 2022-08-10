using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUser _user;

        public AccountController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.returnUrl = returnUrl;
            }

            return View();
        }

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
