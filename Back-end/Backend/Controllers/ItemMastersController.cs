using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Entities;
using Backend.Interfaces;
using Backend.Repositories;

namespace Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ItemMastersController : Controller
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        
        public ItemMastersController(IItemMasterRepository _itemMasterRepository)
        {
            this._itemMasterRepository = _itemMasterRepository;
        }
        [HttpGet]
        public ActionResult GetItem(string id)
        {
            try
            {
                var result = _itemMasterRepository.GetItem(id);
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost] 
        public ActionResult AddItem(ItemMasters itemMasters)
        {
            try
            {
                _itemMasterRepository.AddItem(itemMasters);
                return StatusCode(200);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed,ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditItem(ItemMasters itemMasters)
        {
            try
            {
                _itemMasterRepository.EditItem(itemMasters);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteItem(string id)
        {
            try
            {
                _itemMasterRepository.DeleteItem(id);
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
