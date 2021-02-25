using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpustakaanAPI.Models;
using PerpustakaanAPI.ViewModels;

namespace PerpustakaanAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly DbPerpustakaanContext _context;

        public UserLoginsController(DbPerpustakaanContext context)
        {
            _context = context;
        }

        // GET: api/UserLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLogin>>> GetUserLogin()
        {
            return await _context.UserLogin.ToListAsync();
        }

        // GET: api/UserLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLogin>> GetUserLogin(string id)
        {
            var userLogin = await _context.UserLogin.FindAsync(id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return userLogin;
        }

        // PUT: api/UserLogins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogin(string id, UserLogin userLogin)
        {
            if (id != userLogin.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        // POST: api/UserLogins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserLogin>> PostUserLogin(UserLogin userLogin)
        {
            _context.UserLogin.Add(userLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserLoginExists(userLogin.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserLogin", new { id = userLogin.UserId }, userLogin);
        }

        [HttpPost]
        public async Task<IActionResult> LoLogin([FromBody] UserLogin login)
        {
            LoginResultModel result = new LoginResultModel();
            
            try
            {
                UserLogin userLogin = await _context.UserLogin.Where(a => a.UserId == login.UserId && a.Password == login.Password).FirstOrDefaultAsync();
                if (userLogin == null)
                {
                    throw new Exception("Invalid username or password!");
                }
                result.IsSuccess = true;

                Petugas petugas = await _context.Petugas.FindAsync(login.UserId);
                result.UserDetail = petugas;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.IsSuccess = false;
            }

            return Ok(result);
        }

        // DELETE: api/UserLogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserLogin>> DeleteUserLogin(string id)
        {
            var userLogin = await _context.UserLogin.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            _context.UserLogin.Remove(userLogin);
            await _context.SaveChangesAsync();

            return userLogin;
        }

        private bool UserLoginExists(string id)
        {
            return _context.UserLogin.Any(e => e.UserId == id);
        }
    }
}
