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
    public class DJBoxesController : ControllerBase
    {
        private readonly MyContext _context;

        public DJBoxesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/DJBoxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DJBox>>> GetDJBoxTable()
        {
            return await _context.DJBoxTable.ToListAsync();
        }

        // GET: api/DJBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DJBox>> GetDJBox(int id)
        {
            var dJBox = await _context.DJBoxTable.FindAsync(id);

            if (dJBox == null)
            {
                return NotFound();
            }

            return dJBox;
        }

        // PUT: api/DJBoxes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDJBox(int id, DJBox dJBox)
        {
            if (id != dJBox.id)
            {
                return BadRequest();
            }

            _context.Entry(dJBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DJBoxExists(id))
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

        // POST: api/DJBoxes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DJBox>> PostDJBox(DJBox dJBox)
        {
            _context.DJBoxTable.Add(dJBox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDJBox", new { id = dJBox.id }, dJBox);
        }

        // DELETE: api/DJBoxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDJBox(int id)
        {
            var dJBox = await _context.DJBoxTable.FindAsync(id);
            if (dJBox == null)
            {
                return NotFound();
            }

            _context.DJBoxTable.Remove(dJBox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DJBoxExists(int id)
        {
            return _context.DJBoxTable.Any(e => e.id == id);
        }
    }
}
