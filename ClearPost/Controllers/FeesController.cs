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
    public class FeesController : Controller
    {
        private FeesService _feesService;

        public FeesController(FeesService feesService)
        {
            _feesService = feesService;
        }
        // GET: Fees
        public ActionResult Index()
        {
            var model = _feesService.GetFees();
            return View(model);
        }

        // GET: Fees/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _feesService.GetFeeDetails(id);
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
            var model = _feesService.Create();
            return View(model);
        }

        // POST: Fees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeesViewModel model)
        {
            try
            {
                bool result = _feesService.AddFees(model);
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
                var model = _feesService.GetFeeDetails(id);
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
        public ActionResult Edit(int id, FeesViewModel model)
        {
            try
            {
                bool result = _feesService.UpdateFees(model);

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
                var model = _feesService.GetFeeDetails(id);
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
        public ActionResult Delete(int id, FeesViewModel model)
        {

            try
            {
                bool result = _feesService.DeleteFees(id);

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