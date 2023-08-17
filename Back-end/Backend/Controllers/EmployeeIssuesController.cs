using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Repositories;

namespace Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeIssuesController : Controller
    {
        private readonly IEmployeeIssuesRepository _employeeIssuesRepository;
        
        public EmployeeIssuesController(IEmployeeIssuesRepository _employeeIssuesRepository)
        {
            this._employeeIssuesRepository = _employeeIssuesRepository;
        }
        [HttpGet]
        public ActionResult GetEmployeeIssue(string id)
        {
            try
            {
                var result = _employeeIssuesRepository.GetEmployeeIssue(id);
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost] 
        public ActionResult AddEmployeeIssue(EmployeeIssues employeeIssues)
        {
            try
            {
                _employeeIssuesRepository.AddEmployeeIssue(employeeIssues);
                return StatusCode(200);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed,ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditEmployeeIssue(EmployeeIssues employeeIssues)
        {
            try
            {
                _employeeIssuesRepository.EditEmployeeIssue(employeeIssues);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteEmployeeCard(string id)
        {
            try
            {
                _employeeIssuesRepository.DeleteEmployeeIssue(id);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
