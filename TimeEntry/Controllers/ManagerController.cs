using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TimeEntry.Data;
using TimeEntry.Models;

namespace TimeEntry.Controllers
{
    public class ManagerController : Controller
    {
        private AppDbContext _appDbContext;
        public ManagerController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var employees = _appDbContext.Managers.ToList();
            return View(employees);
        }
        public async Task<IActionResult> ApproveTime()
        {
            var timeSheetEntries = await _appDbContext.Set<TimeSheetEntry>().ToListAsync();
            return View(timeSheetEntries);
        }
        [HttpPost]
        public async Task<IActionResult> ApproveTime(List<TimeSheetEntry> timeEntries)
        {
            foreach (var timeEntry in timeEntries)
            {
                if (!ModelState.IsValid)
                {
                    return View(timeEntry);
                }


                timeEntry.SubmitDate = DateTime.Now;
                timeEntry.Approved = true;
                timeEntry.ManagerId = 1;

                EntityEntry entityEntry = _appDbContext.Entry(timeEntry);

                entityEntry.State = EntityState.Modified;

                await _appDbContext.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
