using System.ComponentModel.DataAnnotations;

namespace TimeEntry.Models
{
    public class Manager 
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
