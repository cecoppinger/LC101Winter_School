﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LC101Winter_School.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LC101Winter_School.Controllers
{
    public class CourseController : Controller
    {
        private static ICourseRepository courseRepository = new CourseRepository(); 

        // GET: Course
        public ActionResult Index()
        {
            List<Course> courses = courseRepository.GetCourses();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course model)
        {
            try
            {
                List<Course> courses = courseRepository.GetCourses();
                model.Id = courses.Count + 1;
                courses.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<int> itemsToDelete)
        {
            try
            {
                List<Course> courses = courseRepository.GetCourses();
                courses.RemoveAll(course => itemsToDelete.Contains(course.Id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddStudent(int id)
        {
            ViewBag.course = courseRepository.GetCourse(id);
            ViewBag.students = StudentController.studentRepository.GetStudents();
 
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(int id, int studentId)
        {
            Course course = courseRepository.GetCourse(id);
            Student student = StudentController.studentRepository.GetStudent(studentId);
            course.AddStudent(student);

            return Redirect("Index");
        }
    }
}