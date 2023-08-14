using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMastersController : ControllerBase
    {
        private readonly LoanDBContext _context;

        public ItemMastersController(LoanDBContext context)
        {
            _context = context;
        }

        // GET: api/ItemMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemMaster>>> GetItemMaster()
        {
          if (_context.ItemMaster == null)
          {
              return NotFound();
          }
            return await _context.ItemMaster.ToListAsync();
        }

        // GET: api/ItemMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemMaster>> GetItemMaster(string id)
        {
          if (_context.ItemMaster == null)
          {
              return NotFound();
          }
            var itemMaster = await _context.ItemMaster.FindAsync(id);

            if (itemMaster == null)
            {
                return NotFound();
            }

            return itemMaster;
        }

        // PUT: api/ItemMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemMaster(string id, ItemMaster itemMaster)
        {
            if (id != itemMaster.itemId)
            {
                return BadRequest();
            }

            _context.Entry(itemMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItemMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemMaster>> PostItemMaster(ItemMaster itemMaster)
        {
          if (_context.ItemMaster == null)
          {
              return Problem("Entity set 'LoanDBContext.ItemMaster'  is null.");
          }
            _context.ItemMaster.Add(itemMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemMasterExists(itemMaster.itemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItemMaster", new { id = itemMaster.itemId }, itemMaster);
        }

        // DELETE: api/ItemMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemMaster(string id)
        {
            if (_context.ItemMaster == null)
            {
                return NotFound();
            }
            var itemMaster = await _context.ItemMaster.FindAsync(id);
            if (itemMaster == null)
            {
                return NotFound();
            }

            _context.ItemMaster.Remove(itemMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemMasterExists(string id)
        {
            return (_context.ItemMaster?.Any(e => e.itemId == id)).GetValueOrDefault();
        }
    }
}
