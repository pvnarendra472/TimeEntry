using Microsoft.AspNetCore.Mvc;
using TimeEntry.Data;
using TimeEntry.Models;

namespace TimeEntry.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext _appDbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var employees = _appDbContext.Employees.ToList();
            return View(employees);
        }
        public IActionResult EnterTime()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnterTime(TimeSheetEntry timeEntry)
        {
            if (!ModelState.IsValid)
            {
                return View(timeEntry);
            }
            timeEntry.SubmitDate = DateTime.Now;
            timeEntry.Approved = false;
            timeEntry.EmployeeId = 1;
            timeEntry.EmployeeName = _appDbContext.Employees?.ToList().FirstOrDefault(c => c.Id == timeEntry.EmployeeId).FullName;

            await _appDbContext.AddAsync(timeEntry);

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
