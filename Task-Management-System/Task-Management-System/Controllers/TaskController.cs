using Microsoft.AspNetCore.Mvc;
using Task_Management_System.BusinessLayer.Contract;
using Task_Management_System.BusinessLayer.Service;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    public class TaskController : Controller
    {
        private readonly IWorkTask _workTask;
        public TaskController(WorkTask workTask)
        {
            _workTask = workTask;

        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateEmployeeTask([FromBody]CreateTask userTaskDetails)
        {
            try 
            {
                await _workTask.CreateEmployeeTask(userTaskDetails);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
            return Ok();
        }



        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateEmployeeTask([FromBody]UpdateTaskDetails updateddata)
        {
            try
            {
                await _workTask.UpdateEmployeeTask(updateddata);
                return Ok("success");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

            return null;

        }

        [HttpGet("ManagerandTLGetTask")]
        public async Task<ActionResult<List<CreateTask>>> GetAllEmployeeTask(ManagerTeamLeadAuthentication managerTeamLeadData)
        {
            try 
            { 
               List<CreateTask> EmployeesData=await _workTask.GetAllTaskRelatedToManagerTL(managerTeamLeadData);

                return EmployeesData;

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Admin")]
        public async Task<ActionResult<List<CreateTask>>> GetAllDataToAdmin()
        {
            try
            {
                List <CreateTask> AllEmployeesData = await _workTask.AllEmployeesDataToAdmin();
                if (AllEmployeesData is null)
                    return NotFound("No Data Available");
                
                return AllEmployeesData;
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }

            

        }
        
    }
}
