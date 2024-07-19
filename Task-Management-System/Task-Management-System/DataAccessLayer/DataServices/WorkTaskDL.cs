using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Task_Management_System.Models;

namespace Task_Management_System.DataAccessLayer.DataServices
{
    public class WorkTaskDL : DbContext
    {

        public WorkTaskDL( DbContextOptions<WorkTaskDL> options) :base(options) 
        {
                
        }
        public DbSet<CreateTask> EmployeeTasks { get; set; }



      

    }
}
