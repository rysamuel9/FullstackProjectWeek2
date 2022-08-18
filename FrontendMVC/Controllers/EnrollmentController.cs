using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontendMVC.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment _enrollment;
        private readonly ICourse _course;
        private readonly IStudent _student;

        public EnrollmentController(IEnrollment enrollment, ICourse course, IStudent student)
        {
            _enrollment = enrollment;
            _course = course;
            _student = student;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _enrollment.GetAll();
            return View(models);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _enrollment.GetById(id);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Course = new SelectList(await _course.GetAll(), "CourseID", "Title");
            ViewBag.Student = new SelectList(await _student.GetAll(), "ID", "LastName");
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(EnrollmentCreateViewModel enrollment)
        //{
        //    try
        //    {
        //        var result = await _enrollment.Insert(enrollment);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            try
            {
                var result = await _enrollment.Insert(enrollment);
                TempData["success"] = $"Enrollment created successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Course = new SelectList(await _course.GetAll(), "CourseID", "Title");
            ViewBag.Student = new SelectList(await _student.GetAll(), "ID", "LastName");
            TempData["success"] = $"Enrollment updated successfully";
            var model = await _enrollment.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Enrollment course)
        {
            try
            {
                var result = await _enrollment.Update(course);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _enrollment.GetById(id);
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _enrollment.Delete(id);
                TempData["success"] = $"Enrollment deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
