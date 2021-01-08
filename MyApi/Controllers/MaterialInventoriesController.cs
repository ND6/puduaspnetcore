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
    public class MaterialInventoriesController : ControllerBase
    {
        private readonly MyContext _context;

        public MaterialInventoriesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/MaterialInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialInventory>>> GetMaterialInventoryTable()
        {
            return await _context.MaterialInventoryTable.ToListAsync();
        }

        // GET: api/MaterialInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialInventory>> GetMaterialInventory(int id)
        {
            var materialInventory = await _context.MaterialInventoryTable.FindAsync(id);

            if (materialInventory == null)
            {
                return NotFound();
            }

            return materialInventory;
        }

        // PUT: api/MaterialInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialInventory(int id, MaterialInventory materialInventory)
        {
            if (id != materialInventory.id)
            {
                return BadRequest();
            }

            _context.Entry(materialInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialInventoryExists(id))
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

        // POST: api/MaterialInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaterialInventory>> PostMaterialInventory(MaterialInventory materialInventory)
        {
            _context.MaterialInventoryTable.Add(materialInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialInventory", new { id = materialInventory.id }, materialInventory);
        }

        // DELETE: api/MaterialInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialInventory(int id)
        {
            var materialInventory = await _context.MaterialInventoryTable.FindAsync(id);
            if (materialInventory == null)
            {
                return NotFound();
            }

            _context.MaterialInventoryTable.Remove(materialInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialInventoryExists(int id)
        {
            return _context.MaterialInventoryTable.Any(e => e.id == id);
        }
    }
}
