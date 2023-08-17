using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Repositories;

namespace Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoanCardMastersController : Controller
    {
        private readonly ILoanCardMastersRepository _loanCardMastersRepository;
        
        public LoanCardMastersController(ILoanCardMastersRepository _loanCardMastersRepository)
        {
            this._loanCardMastersRepository = _loanCardMastersRepository;
        }
        [HttpGet]
        public ActionResult GetLoanCard(string id)
        {
            try
            {
                var result = _loanCardMastersRepository.GetLoanCard(id);
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost] 
        public ActionResult AddLoanCard(LoanCardMasters loanCardMasters)
        {
            try
            {
                _loanCardMastersRepository.AddLoanCard(loanCardMasters);
                return StatusCode(200);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed,ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditLoanCard(LoanCardMasters loanCardMasters)
        {
            try
            {
                _loanCardMastersRepository.EditLoanCard(loanCardMasters);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteLoanCard(string id)
        {
            try
            {
                _loanCardMastersRepository.DeleteLoanCard(id);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
