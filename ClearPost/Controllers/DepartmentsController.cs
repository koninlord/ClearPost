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
    public class DepartmentsController : Controller
    {
        private DepartmentService _departmentService;
        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: Departments
        public ActionResult Index()
        {
            var model = _departmentService.GetDepartments();
            return View(model);
        }


        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel model)
        {
            try
            {
                bool result = _departmentService.AddDepartment(model);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _departmentService.GetDepartmentDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentViewModel model)
        {
            try
            {
                bool result = _departmentService.UpdateDepartment(model);

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

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _departmentService.GetDepartmentDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DepartmentViewModel model)
        {
            try
            {
                bool result = _departmentService.RemoveDepartment(id);

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