using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursesApplication.Domain.Models;
using CoursesApplication.Repository.Data;
using CoursesApplication.Service.Interface;

namespace CoursesApplication.Web.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        // GET: Enrollments/Create/CourseId
        // TODO: Add the CourseId as parameter and use it in the view as a value for the hidden input
        // Use the SelectList to populate the drop-down list in the view
        // Replace the usage of ApplicationDbContext with the appropriate service
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_enrollmentService.Students, "Id", "Index");
            return View();
        }
        // POST: Enrollments/Create
        // TODO: Bind the form from the view to this POST action in order to create the Enrollement
        // Implement the IEnrollmentService and use it here to create the enrollment
        // After successful creation, the user should be redirected to Index page of Courses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateEnrolled,ReEnrolled,StudentId,CourseId")] Enrollment enrollment)
        {
            return RedirectToAction();
        }
    }
}
