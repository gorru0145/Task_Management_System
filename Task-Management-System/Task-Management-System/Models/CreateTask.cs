using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class CreateTask
    {

        
        public required int EmployeeId { get; set; }
        public DateOnly StartDateOnly { get; set; }
        public DateOnly EndDateOnly { get; set; }
        public required string EmployeeName { get; set; }
        public required string ManagerName { get; set; }
        public required string TeamLeadName {  get; set; }
        public byte[]? Document { get; set; }
        public string TaskDesription { get; set; }
        public string TaskStatus { get; set; }
        public string Notes { get; set; }
        [Key]
        public int IndivisualTaskId { get; set; }


    }
}
