using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearPost.Models.Data.FlearanceDbContext;
using Microsoft.AspNetCore.Mvc;

namespace ClearPost.Controllers
{
    public class HallsDeletedController : Controller
    {
        private readonly FlearanceContext _context;

        public HallsDeletedController(FlearanceContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var deletedRecords = _context.Halls.Where(x => x.RecStatus == 'D').ToList();
            return View(deletedRecords);
        }

        public async Task<IActionResult> Recover(int id)
        {
            var deletedRecord = _context.Halls.FirstOrDefault(x => x.HallId == id);
            deletedRecord.RecStatus = 'A';
            _context.Halls.Update(deletedRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}