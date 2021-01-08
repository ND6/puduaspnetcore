using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DJCabinetsController : ControllerBase
    {
        private readonly MyContext _context;

        public DJCabinetsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/DJCabinets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DJCabinet>>> GetDJCabinetTable()
        {
            return await _context.DJCabinetTable.ToListAsync();
        }

        // GET: api/DJCabinets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DJCabinet>> GetDJCabinet(int id)
        {
            var dJCabinet = await _context.DJCabinetTable.FindAsync(id);

            if (dJCabinet == null)
            {
                return NotFound();
            }

            return dJCabinet;
        }

        // PUT: api/DJCabinets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDJCabinet(int id, DJCabinet dJCabinet)
        {
            if (id != dJCabinet.id)
            {
                return BadRequest();
            }

            _context.Entry(dJCabinet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DJCabinetExists(id))
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

        // POST: api/DJCabinets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DJCabinet>> PostDJCabinet(DJCabinet dJCabinet)
        {
            _context.DJCabinetTable.Add(dJCabinet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDJCabinet", new { id = dJCabinet.id }, dJCabinet);
        }

        // DELETE: api/DJCabinets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDJCabinet(int id)
        {
            var dJCabinet = await _context.DJCabinetTable.FindAsync(id);
            if (dJCabinet == null)
            {
                return NotFound();
            }

            _context.DJCabinetTable.Remove(dJCabinet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DJCabinetExists(int id)
        {
            return _context.DJCabinetTable.Any(e => e.id == id);
        }
    }
}
