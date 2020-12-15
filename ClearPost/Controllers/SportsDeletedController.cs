using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearPost.Models.Data.FlearanceDbContext;
using Microsoft.AspNetCore.Mvc;

namespace ClearPost.Controllers
{
    public class SportsDeletedController : Controller
    {
        private readonly FlearanceContext _context;

        public SportsDeletedController(FlearanceContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var deletedRecords = _context.Sports.Where(x => x.RecStatus == 'D').ToList();
            return View(deletedRecords);
        }

        public async Task<IActionResult> Recover(int id)
        {
            var deletedRecord = _context.Sports.FirstOrDefault(x => x.SportId == id);
            deletedRecord.RecStatus = 'A';
            _context.Sports.Update(deletedRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}