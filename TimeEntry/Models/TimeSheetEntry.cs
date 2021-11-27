using System.ComponentModel.DataAnnotations;
using TimeEntry.Data.Enums;

namespace TimeEntry.Models
{
    public class TimeSheetEntry
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        [Required(ErrorMessage ="Please enter Work Date")]
        public DateTime WorkDate { get; set; }
        public DateTime SubmitDate { get; set; }
        
        [Required(ErrorMessage ="Please enter start time")]
        public DateTime StartTime { get; set; }
        
        [Required(ErrorMessage ="Please enter end time")]
        public DateTime EndTime { get; set; }
        
        [Required(ErrorMessage ="Please select workorder")]
        public WorkOrder WorkOrder { get; set; }
        public int ManagerId { get; set; }
        public bool Approved { get; set; }

    }
}
