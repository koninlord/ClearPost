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
    public class SportsClearController : Controller
    {
        private SportsClear _sportsClear;

        public SportsClearController(SportsClear sportsClear)
        {
            _sportsClear = sportsClear;
        }
        // GET: SportsClear
        public ActionResult Index()
        {
            var model = _sportsClear.GetSports();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var model = _sportsClear.GetSportsDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: FeesClearance/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SportsViewModel model)
        {

            try
            {
                bool result = _sportsClear.DeleteSports(id);

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