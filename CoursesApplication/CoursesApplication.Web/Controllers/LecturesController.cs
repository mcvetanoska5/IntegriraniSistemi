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
    public class LecturesController : Controller
    {
        private readonly ILectureService _lectureService;
        public LecturesController(ILectureService productService)
        {
            _lectureService = productService;
        }
        // GET: Lectures
        public IActionResult Index()
        {
            return View(_lectureService.GetAll());
        }
        // GET: Lectures/Details/5
        public IActionResult Details(Guid id)
        {
            var lecture = _lectureService.GetById(id);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }
        // GET: Lectures/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Date, CourseId, Course")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                _lectureService.Insert(lecture);
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }
        // GET: Lectures/Edit/5
        public IActionResult Edit(Guid pid)
        {
            var lecture = _lectureService.GetById(pid);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }
        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id, Name, Date, CourseId, Course")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }
            _lectureService.Update(lecture);
            return RedirectToAction(nameof(Index));
        }
        // GET: Lectures/Delete/5
        public IActionResult Delete(Guid id)
        {
            var lecture = _lectureService.GetById(id);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }
        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _lectureService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
