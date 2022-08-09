using FrontendMVC.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }
        public async Task<IActionResult> Index()
        {
            var results = await _course.GetAll();
            string strResult = string.Empty;
            foreach (var result in results)
            {
                strResult += result.Title + "\n";
            }
            return Content(strResult);
            //return View();
        }
    }
}
