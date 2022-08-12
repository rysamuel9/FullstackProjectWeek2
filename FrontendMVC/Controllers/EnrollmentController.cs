using FrontendMVC.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment _enrollment;

        public EnrollmentController(IEnrollment enrollment)
        {
            _enrollment = enrollment;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
