using FrontendMVC.Models;
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

        public async Task<IActionResult> Index(int pg = 1)
        {
            var models = await _student.GetAll();

            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = models.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = models.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            //return View(models);

            return View(data);
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

        public async Task<IActionResult> Update(int id)
        {
            var model = await _student.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            try
            {
                var result = await _student.Update(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _student.GetById(id);
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _student.Delete(id);
                TempData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Berhasil mendelete data course id: {id}</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> WithEnrollment()
        {
            var model = await _student.GetWithEnrollment();
            return View(model);
        }
    }
}
