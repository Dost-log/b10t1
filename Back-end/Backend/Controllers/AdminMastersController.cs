using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;
using Backend.Model;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMastersController : ControllerBase
    {
        private readonly LoanDBContext _context;

        public AdminMastersController(LoanDBContext context)
        {
            _context = context;
        }
       // public IActionResult Authenticate(AdminMaster admin)
       // {
          //  var currentUser = .AdminMaster.FirstOrDefault(o => o.Username.ToLower() == admin.UserId.ToLower() && o.Password == admin.password);
       // }
        //public IActionResult Login([FromBody] AdminMaster admin)
        //{
            //var user = Authenticate(admin);
            //if (user != null)
            //{
               // var token = Generate(user);
             //   return Ok(token);
           // }
         //   return NotFound("User not found");
       // }
        // GET: api/AdminMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminMaster>>> GetAdminMaster()
        {
          if (_context.AdminMaster == null)
          {
              return NotFound();
          }
            return await _context.AdminMaster.ToListAsync();
        }

        // GET: api/AdminMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminMaster>> GetAdminMaster(string id)
        {
          if (_context.AdminMaster == null)
          {
              return NotFound();
          }
            var adminMaster = await _context.AdminMaster.FindAsync(id);

            if (adminMaster == null)
            {
                return NotFound();
            }

            return adminMaster;
        }

        // PUT: api/AdminMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminMaster(string id, AdminMaster adminMaster)
        {
            if (id != adminMaster.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(adminMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminMasterExists(id))
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

        // POST: api/AdminMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminMaster>> PostAdminMaster(AdminMaster adminMaster)
        {
          if (_context.AdminMaster == null)
          {
              return Problem("Entity set 'LoanDBContext.AdminMaster'  is null.");
          }
            _context.AdminMaster.Add(adminMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminMasterExists(adminMaster.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdminMaster", new { id = adminMaster.EmployeeId }, adminMaster);
        }

        // DELETE: api/AdminMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminMaster(string id)
        {
            if (_context.AdminMaster == null)
            {
                return NotFound();
            }
            var adminMaster = await _context.AdminMaster.FindAsync(id);
            if (adminMaster == null)
            {
                return NotFound();
            }

            _context.AdminMaster.Remove(adminMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminMasterExists(string id)
        {
            return (_context.AdminMaster?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
