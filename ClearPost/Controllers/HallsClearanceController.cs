using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearPost.Models.Services;
using ClearPost.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ClearPost.Controllers
{
    public class HallsClearanceController : Controller
    {
        private HallsClear _hallsClear;

        public HallsClearanceController(HallsClear hallsClear)
        {
            _hallsClear = hallsClear;
        }
        public IActionResult Index()
        {
            var model = _hallsClear.GetHalls();
            return View(model);
        }
        // GET: Halls/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _hallsClear.GetHallDetails(id);
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
                bool result = _hallsClear.DeleteHalls(id);

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