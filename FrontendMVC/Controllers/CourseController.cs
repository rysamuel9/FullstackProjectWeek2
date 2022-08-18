using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Index(int pg = 1)
        {
            var model = await _course.GetAll();

            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = model.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = model.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            //return View(model);

            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _course.GetById(id);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateViewModel course)
        {
            try
            {
                var result = await _course.Insert(course);
                TempData["success"] = $"Course {course.Title} successfully added";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _course.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            try
            {
                var result = await _course.Update(course);
                TempData["success"] = $"Course updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _course.GetById(id);
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _course.Delete(id);
                TempData["success"] = $"Course {id} successfully deleted";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
