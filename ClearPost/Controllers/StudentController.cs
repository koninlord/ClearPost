using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearPost.Models.Services;
using ClearPost.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClearPost.Controllers
{
    public class StudentController : Controller
    {
        private StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        } 

        // GET: Student
        public ActionResult Index()
        {
            var model = _studentService.GetStudents();
            return View(model);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _studentService.GetStudentDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            var model = _studentService.Create();
            return View(model);
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel model)
        {
            try
            {
                bool result = _studentService.AddStudent(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();

            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ooops! Something went wrong!");
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _studentService.GetStudentDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentViewModel model)
        {
            try
            {
                bool result = _studentService.UpdateStudent(model);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ooops! Something went wrong!");
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _studentService.GetStudentDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StudentViewModel model)
        {
            try
            {
                bool result = _studentService.DeleteStudent(id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ooops! Something went wrong!");
                return View();
            }
        }
    }
}