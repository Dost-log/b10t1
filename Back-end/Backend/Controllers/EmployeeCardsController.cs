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
    public class EmployeeCardsController : ControllerBase
    {
        private readonly LoanDBContext _context;

        public EmployeeCardsController(LoanDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeCard>>> GetEmployeeCard()
        {
          if (_context.EmployeeCard == null)
          {
              return NotFound();
          }
            return await _context.EmployeeCard.ToListAsync();
        }

        // GET: api/EmployeeCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeCard>> GetEmployeeCard(string id)
        {
          if (_context.EmployeeCard == null)
          {
              return NotFound();
          }
            var employeeCard = await _context.EmployeeCard.FindAsync(id);

            if (employeeCard == null)
            {
                return NotFound();
            }

            return employeeCard;
        }

        // PUT: api/EmployeeCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeCard(string id, EmployeeCard employeeCard)
        {
            if (id != employeeCard.LoanId)
            {
                return BadRequest();
            }

            _context.Entry(employeeCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeCardExists(id))
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

        // POST: api/EmployeeCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeCard>> PostEmployeeCard(EmployeeCard employeeCard)
        {
          if (_context.EmployeeCard == null)
          {
              return Problem("Entity set 'LoanDBContext.EmployeeCard'  is null.");
          }
            _context.EmployeeCard.Add(employeeCard);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeCardExists(employeeCard.LoanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeCard", new { id = employeeCard.LoanId }, employeeCard);
        }

        // DELETE: api/EmployeeCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeCard(string id)
        {
            if (_context.EmployeeCard == null)
            {
                return NotFound();
            }
            var employeeCard = await _context.EmployeeCard.FindAsync(id);
            if (employeeCard == null)
            {
                return NotFound();
            }

            _context.EmployeeCard.Remove(employeeCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeCardExists(string id)
        {
            return (_context.EmployeeCard?.Any(e => e.LoanId == id)).GetValueOrDefault();
        }
    }
}
