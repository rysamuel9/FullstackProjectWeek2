using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FrontendMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourse _course;
        private readonly IStudent _student;
        private readonly IEnrollment _enrollment;

        public HomeController(ILogger<HomeController> logger, ICourse course, IStudent student, IEnrollment enrollment)
        {
            _logger = logger;
            _course = course;
            _student = student;
            _enrollment = enrollment;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Course = await _course.GetAll();
            ViewBag.Student = await _student.GetAll();
            ViewBag.Enrollment = await _enrollment.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}