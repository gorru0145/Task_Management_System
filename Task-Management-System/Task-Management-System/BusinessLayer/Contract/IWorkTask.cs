using Task_Management_System.Models;

namespace Task_Management_System.BusinessLayer.Contract
{
    public interface IWorkTask
    {
        public  Task<CreateTask> UpdateEmployeeTask(UpdateTaskDetails getUpdatedTaskData);
        public Task<string> CreateEmployeeTask(CreateTask userDetails);
        public Task<List<CreateTask>> GetAllTaskRelatedToManagerTL(ManagerTeamLeadAuthentication managerTeamLeadData);
        public Task<List<CreateTask>> AllEmployeesDataToAdmin();
    }
}
