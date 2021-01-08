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
    public class OperatingRecordsController : ControllerBase
    {
        private readonly MyContext _context;

        public OperatingRecordsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/OperatingRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperatingRecord>>> GetOpenBoxRecordTable()
        {
            return await _context.OpenBoxRecordTable.ToListAsync();
        }

        // GET: api/OperatingRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperatingRecord>> GetOperatingRecord(int id)
        {
            var operatingRecord = await _context.OpenBoxRecordTable.FindAsync(id);

            if (operatingRecord == null)
            {
                return NotFound();
            }

            return operatingRecord;
        }

        // PUT: api/OperatingRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperatingRecord(int id, OperatingRecord operatingRecord)
        {
            if (id != operatingRecord.id)
            {
                return BadRequest();
            }

            _context.Entry(operatingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperatingRecordExists(id))
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

        // POST: api/OperatingRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperatingRecord>> PostOperatingRecord(OperatingRecord operatingRecord)
        {
            _context.OpenBoxRecordTable.Add(operatingRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperatingRecord", new { id = operatingRecord.id }, operatingRecord);
        }

        // DELETE: api/OperatingRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperatingRecord(int id)
        {
            var operatingRecord = await _context.OpenBoxRecordTable.FindAsync(id);
            if (operatingRecord == null)
            {
                return NotFound();
            }

            _context.OpenBoxRecordTable.Remove(operatingRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperatingRecordExists(int id)
        {
            return _context.OpenBoxRecordTable.Any(e => e.id == id);
        }
    }
}
