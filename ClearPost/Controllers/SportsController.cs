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
    public class SportsController : Controller
    {

        private SportsService _sportsService;

        public SportsController(SportsService sportsService)
        {
            _sportsService = sportsService;
        }
        // GET: Fees
        public ActionResult Index()
        {
            var model = _sportsService.GetSports();
            return View(model);
        }

        // GET: Fees/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _sportsService.GetSportsDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Fees/Create
        public ActionResult Create()
        {
            var model = _sportsService.Create();
            return View(model);
        }

        // POST: Fees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SportsViewModel model)
        {
            try
            {
                bool result = _sportsService.AddSports(model);
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

        // GET: Fees/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _sportsService.GetSportsDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Fees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SportsViewModel model)
        {
            try
            {
                bool result = _sportsService.UpdateSports(model);

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

        // GET: Fees/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _sportsService.GetSportsDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Fees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SportsViewModel model)
        {

            try
            {
                bool result = _sportsService.DeleteSports(id);

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