﻿using FrontendMVC.Services.IRepository;
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
            var model = await _course.GetAll();
            return View(model);
        }
    }
}
