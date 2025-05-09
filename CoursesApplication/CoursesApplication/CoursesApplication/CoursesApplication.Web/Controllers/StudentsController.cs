using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursesApplication.Domain.Models;
using CoursesApplication.Repository.Data;
using System.Security.Claims;
using CoursesApplication.Service.Interface;

namespace CoursesApplication.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: Students
        public IActionResult Index()
        {
            return View(_studentService.GetAll());
        }
        // GET: Students/Details/5
        public IActionResult Details(Guid id)
        {
            var product = _studentService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Surname, DateOfBirth, Index, EnrollmentYear, Enrollments")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Insert(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        // GET: Students/Edit/5
        public IActionResult Edit(Guid pid)
        {
            var student = _studentService.GetById(pid);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id, Name, Surname, DateOfBirth, Index, EnrollmentYear, Enrollments")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            _studentService.Update(student);
            return RedirectToAction(nameof(Index));
        }
        // GET: Studrnts/Delete/5
        public IActionResult Delete(Guid id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _studentService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
