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
    public class EmployeeIssuesController : ControllerBase
    {
        private readonly LoanDBContext _context;

        public EmployeeIssuesController(LoanDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeIssue>>> GetEmployeeIssue()
        {
          if (_context.EmployeeIssue == null)
          {
              return NotFound();
          }
            return await _context.EmployeeIssue.ToListAsync();
        }

        // GET: api/EmployeeIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeIssue>> GetEmployeeIssue(string id)
        {
          if (_context.EmployeeIssue == null)
          {
              return NotFound();
          }
            var employeeIssue = await _context.EmployeeIssue.FindAsync(id);

            if (employeeIssue == null)
            {
                return NotFound();
            }

            return employeeIssue;
        }

        // PUT: api/EmployeeIssues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeIssue(string id, EmployeeIssue employeeIssue)
        {
            if (id != employeeIssue.issueId)
            {
                return BadRequest();
            }

            _context.Entry(employeeIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeIssueExists(id))
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

        // POST: api/EmployeeIssues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeIssue>> PostEmployeeIssue(EmployeeIssue employeeIssue)
        {
          if (_context.EmployeeIssue == null)
          {
              return Problem("Entity set 'LoanDBContext.EmployeeIssue'  is null.");
          }
            _context.EmployeeIssue.Add(employeeIssue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeIssueExists(employeeIssue.issueId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeIssue", new { id = employeeIssue.issueId }, employeeIssue);
        }

        // DELETE: api/EmployeeIssues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeIssue(string id)
        {
            if (_context.EmployeeIssue == null)
            {
                return NotFound();
            }
            var employeeIssue = await _context.EmployeeIssue.FindAsync(id);
            if (employeeIssue == null)
            {
                return NotFound();
            }

            _context.EmployeeIssue.Remove(employeeIssue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeIssueExists(string id)
        {
            return (_context.EmployeeIssue?.Any(e => e.issueId == id)).GetValueOrDefault();
        }
    }
}
