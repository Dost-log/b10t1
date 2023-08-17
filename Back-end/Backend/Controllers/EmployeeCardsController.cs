using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Repositories;

namespace Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeCardsController : Controller
    {
        private readonly IEmployeeCardsRepository _employeeCardsRepository;
        
        public EmployeeCardsController(IEmployeeCardsRepository _employeeCardsRepository)
        {
            this._employeeCardsRepository = _employeeCardsRepository;
        }
        [HttpGet]
        public ActionResult GetEmployeeCard(string id)
        {
            try
            {
                var result = _employeeCardsRepository.GetEmployeeCard(id);
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost] 
        public ActionResult AddEmployeeCard(EmployeeCards _employeeCards)
        {
            try
            {
                _employeeCardsRepository.AddEmployeeCard(_employeeCards);
                return StatusCode(200);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed,ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditEmployeeCard(EmployeeCards _employeeCards)
        {
            try
            {
                _employeeCardsRepository.EditEmployeeCard(_employeeCards);
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
                _employeeCardsRepository.DeleteEmployeeCard(id);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
