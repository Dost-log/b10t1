using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Entities;
using Backend.Services;
using Backend.Model; 

namespace Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminMastersController : Controller
    {
        private readonly IAdminMastersRepository _adminMastersRepository;
        
        public AdminMastersController(IAdminMastersRepository _adminMastersRepository)
        {
            this._adminMastersRepository = _adminMastersRepository;
        }
        [HttpGet]
        public ActionResult GetAdmin(string id)
        {
            try
            {
                var result = _adminMastersRepository.GetAdmin(id);
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpPost] 
        public ActionResult AddAdmin(AdminMasters _adminMasters)
        {
            try
            {
                _adminMastersRepository.AddAdmin(_adminMasters);
                return StatusCode(200);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed,ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditAdmin(AdminMasters _adminMasters)
        {
            try
            {
                _adminMastersRepository.EditAdmin(_adminMasters);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteAdmin(string id)
        {
            try
            {
                _adminMastersRepository.DeleteAdmin(id);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult LoginAdminMasters(string id,string password)
        {
            try
            {
                var result = _adminMastersRepository.LoginAdminMasters(id,password);
                if (result == null) {
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
    }
}
