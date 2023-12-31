﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Repositories;
using Backend.Services;
using Backend.DTO;

namespace Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeMastersController : Controller
    {
        private readonly IEmployeeMastersRepository _employeeMastersRepository;
        
        public EmployeeMastersController(IEmployeeMastersRepository _employeeMastersRepository)
        {
            this._employeeMastersRepository = _employeeMastersRepository;
        }
        [HttpGet]
        public ActionResult GetEmployee(string id)
        {
            try
            {
                var result = _employeeMastersRepository.GetEmployee(id);
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost] 
        public ActionResult AddEmployee(EmployeeMasters employeeMasters)
        {
            try
            {
                _employeeMastersRepository.AddEmployee(employeeMasters);
                return StatusCode(200);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed,ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeMasters employeeMasters)
        {
            try
            {
                _employeeMastersRepository.EditEmployee(employeeMasters);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteEmployee(string id)
        {
            try
            {
                _employeeMastersRepository.DeleteEmployee(id);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult LoginEmployeeMasters(string id, string password)
        {
            try
            {
                var result = _employeeMastersRepository.LoginEmployeeMasters(id, password);
                if (result == null)
                {
                    return StatusCode(400, "Invalid Credentials");
                }
                else
                {
                    if (result.password == password)
                    {
                        return StatusCode(200, result);
                    }
                    else
                    {
                        return StatusCode(400, "Invalid Credentials");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllEmployeeMasters()
        {
            try
            {
                return StatusCode(200, _employeeMastersRepository.GetAllEmployeeMasters());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult ApplyLoan(ApplyLoanDTO applyLoanDTO)
        {
            try
            {
                return StatusCode(200, _employeeMastersRepository.ApplyLoan(applyLoanDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult LoanCardsAvailed(string id)
        {
            try
            {
                return StatusCode(200, _employeeMastersRepository.LoanCardsAvailed(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult ItemsPurchased(string id)
        {
            try
            {
                return StatusCode(200, _employeeMastersRepository.ItemsPurchased(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
