using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
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
        public async Task<IActionResult> Index()
        {
            var models = await _enrollment.GetAll();
            return View(models);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await _enrollment.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnrollmentCreateViewModel enrollment)
        {
            try
            {
                var result = await _enrollment.Insert(enrollment);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
