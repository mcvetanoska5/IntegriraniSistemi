﻿using System;
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
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: Courses
        public IActionResult Index()
        {
            return View(_courseService.GetAll());
        }
        // GET: Courses/Details/5
        public IActionResult Details(Guid id)
        {
            var course = _courseService.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Semester, Courses")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.Insert(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        // GET: Courses/Edit/5
        public IActionResult Edit(Guid pid)
        {
            var course = _courseService.GetById(pid);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id, Name, Semester, Courses")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }
            _courseService.Update(course);
            return RedirectToAction(nameof(Index));
        }
        // GET: Courses/Delete/5
        public IActionResult Delete(Guid id)
        {
            var course = _courseService.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _courseService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
