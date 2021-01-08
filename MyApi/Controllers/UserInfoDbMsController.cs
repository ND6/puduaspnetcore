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
    public class UserInfoDbMsController : ControllerBase
    {
        private readonly MyContext _context;

        public UserInfoDbMsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoDbMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfoDbM>>> GetUserInfoTable()
        {
            return await _context.UserInfoTable.ToListAsync();
        }

        // GET: api/UserInfoDbMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfoDbM>> GetUserInfoDbM(int id)
        {
            var userInfoDbM = await _context.UserInfoTable.FindAsync(id);

            if (userInfoDbM == null)
            {
                return NotFound();
            }

            return userInfoDbM;
        }

        // PUT: api/UserInfoDbMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfoDbM(int id, UserInfoDbM userInfoDbM)
        {
            if (id != userInfoDbM.id)
            {
                return BadRequest();
            }

            _context.Entry(userInfoDbM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoDbMExists(id))
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

        // POST: api/UserInfoDbMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfoDbM>> PostUserInfoDbM(UserInfoDbM userInfoDbM)
        {
            _context.UserInfoTable.Add(userInfoDbM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfoDbM", new { id = userInfoDbM.id }, userInfoDbM);
        }

        // DELETE: api/UserInfoDbMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfoDbM(int id)
        {
            var userInfoDbM = await _context.UserInfoTable.FindAsync(id);
            if (userInfoDbM == null)
            {
                return NotFound();
            }

            _context.UserInfoTable.Remove(userInfoDbM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoDbMExists(int id)
        {
            return _context.UserInfoTable.Any(e => e.id == id);
        }
    }
}
