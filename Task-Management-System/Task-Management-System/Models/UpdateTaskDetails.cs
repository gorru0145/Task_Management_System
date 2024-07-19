namespace Task_Management_System.Models
{
    public class UpdateTaskDetails
    {
        public int IndivisualTaskId { get; set; }
        public int EmployeeId { get; set; }
        public string TaskStatus { get; set; }
        public string TaskDesription { get; set; }
        public byte[]? Document { get; set; }
        public string Notes { get; set; }
        public required string EmployeeName { get; set; }
        public required string ManagerName { get; set; }
        public required string TeamLeadName { get; set; }


    }
}
