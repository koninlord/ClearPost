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
    public class HallsController : Controller
    {
        private HallService _hallService;

        public HallsController(HallService hallService)
        {
            _hallService = hallService;
        }
        // GET: Halls
        public ActionResult Index()
        {
            var model = _hallService.GetHalls();
            return View(model);
        }
     
        // GET: Halls/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _hallService.GetHallDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Halls/Create
        public ActionResult Create()
        {
            var model = _hallService.Create();
            return View(model);
        }

        // POST: Halls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HallViewModel model)
        {
            try
            {
                bool result = _hallService.AddHalls(model);
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

        // GET: Halls/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _hallService.GetHallDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Halls/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HallViewModel model)
        {
            try
            {
                bool result = _hallService.UpdateHalls(model);

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

        // GET: Halls/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _hallService.GetHallDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Halls/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, HallViewModel model)
        {
            try
            {
                bool result = _hallService.DeleteHalls(id);

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