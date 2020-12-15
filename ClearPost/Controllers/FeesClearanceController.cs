using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearPost.Models.Services;
using ClearPost.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClearPost.Controllers
{
    public class FeesClearanceController : Controller
    {
        private FeesClear _feesClear;

        public FeesClearanceController(FeesClear feesClear)
        {
            _feesClear = feesClear;
        }
        
        // GET: FeesClearance
        public ActionResult Index()
        {
            var model = _feesClear.GetFees();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var model = _feesClear.GetFeeDetails(id);
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
        public ActionResult Delete(int id, FeesViewModel model)
        {

            try
            {
                bool result = _feesClear.DeleteFees(id);

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