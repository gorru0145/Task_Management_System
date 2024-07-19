using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Task_Management_System.BusinessLayer.Contract;
using Task_Management_System.DataAccessLayer.DataServices;
using Task_Management_System.Models;

namespace Task_Management_System.BusinessLayer.Service
{
    public class WorkTask : IWorkTask
    {
        private readonly DataAccessLayer.DataServices.WorkTaskDL _workTask;
        public WorkTask(WorkTaskDL workTask)
        {
            _workTask = workTask;
        }

        public async Task<string> CreateEmployeeTask(CreateTask userTaskDetails)
        {
            try
            {
                //create new employee task
                _workTask.EmployeeTasks.Add(userTaskDetails);
                await _workTask.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Exception occur while adding new task of employee");
            }
            return string.Empty;
        }
        public async Task<CreateTask> UpdateEmployeeTask(UpdateTaskDetails getUpdatedTaskData) 
        {
            try
            {
                //update task 
                var GetEmployeeData =await _workTask.EmployeeTasks.FindAsync(getUpdatedTaskData.IndivisualTaskId);
                if (getUpdatedTaskData is null)
                    throw new Exception("TaskId Not Found ");
                else
                {
                    GetEmployeeData.TaskDesription= getUpdatedTaskData.TaskDesription;
                    GetEmployeeData.TaskStatus= getUpdatedTaskData.TaskStatus;
                    GetEmployeeData.Document= getUpdatedTaskData.Document;
                    GetEmployeeData.Notes= getUpdatedTaskData.Notes;
                    GetEmployeeData.EmployeeName= getUpdatedTaskData.EmployeeName;
                    GetEmployeeData.ManagerName= getUpdatedTaskData.ManagerName;
                    GetEmployeeData.TeamLeadName= getUpdatedTaskData.TeamLeadName;
                    GetEmployeeData.EmployeeId= getUpdatedTaskData.EmployeeId;

                    await _workTask.SaveChangesAsync();
                }
               
                return null;
            }
            catch (Exception ex) 
            {
                throw new Exception("Not Able to Update data");
            }
           

        }

        public async Task<List<CreateTask>> GetAllTaskRelatedToManagerTL(ManagerTeamLeadAuthentication managerTeamLeadData)
        {
            try
            {
                // get employees list to aligned manager
                var EmpDataRelatedToGivenManager=_workTask.EmployeeTasks.Where(e=>e.ManagerName.Equals(managerTeamLeadData)   || e.TeamLeadName.Equals(managerTeamLeadData)   ).ToList();
                return EmpDataRelatedToGivenManager;
            }
            catch (Exception ex)
            {
                throw new Exception("Not Able to Fetch data");
            }
        }

        public async Task<List<CreateTask>> AllEmployeesDataToAdmin()
        {
            try
            {
                // get all employee data for admin
                var AllEmployeesdata = _workTask.EmployeeTasks.ToListAsync();
                
                    return AllEmployeesdata.Result;
                
            }
            catch (Exception ex) 
            {
                throw new Exception($"Exception while fetching data");
            }
            
        }

    }
}
