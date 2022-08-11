using FrontendMVC.Services.IRepository;
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
    }
}
