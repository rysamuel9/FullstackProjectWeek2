using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _student.GetAll();
            return View(models);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _student.GetById(id);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateViewModel course)
        {
            try
            {
                var result = await _student.Insert(course);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
