using Microsoft.EntityFrameworkCore;
using TimeEntry.Models;

namespace TimeEntry.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<TimeSheetEntry> TimeSheetEntries { get; set; }


    }
}
