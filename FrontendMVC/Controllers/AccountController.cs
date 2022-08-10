using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
