using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearPost.Models.Data.FlearanceDbContext;
using ClearPost.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ClearPost.Controllers
{
    public class FeesDeletedController : Controller
    {
        private readonly FlearanceContext _context;
      
        public FeesDeletedController(FlearanceContext context)
        {
            _context = context;
          
        }
        public IActionResult Index()
        {
            var deletedRecords = _context.Fees.Where(x => x.RecStatus == 'D').ToList();
            return View(deletedRecords);
        }

        public async Task<IActionResult> Recover(int id)
        {
            var deletedRecord = _context.Fees.FirstOrDefault(x => x.FeeId == id);
            deletedRecord.RecStatus = 'A';
            _context.Fees.Update(deletedRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}