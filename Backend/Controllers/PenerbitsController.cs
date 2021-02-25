using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpustakaanAPI.Models;

namespace PerpustakaanAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PenerbitsController : ControllerBase
    {
        private readonly DbPerpustakaanContext _context;

        public PenerbitsController(DbPerpustakaanContext context)
        {
            _context = context;
        }

        // GET: api/Penerbits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Penerbit>>> GetPenerbit()
        {
            return await _context.Penerbit.ToListAsync();
        }

        // GET: api/Penerbits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Penerbit>> GetPenerbit(string id)
        {
            var penerbit = await _context.Penerbit.FindAsync(id);

            if (penerbit == null)
            {
                return NotFound();
            }

            return penerbit;
        }

        // PUT: api/Penerbits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPenerbit(string id, Penerbit penerbit)
        {
            if (id != penerbit.KdPenerbit)
            {
                return BadRequest();
            }

            _context.Entry(penerbit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PenerbitExists(id))
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

        // POST: api/Penerbits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Penerbit>> PostPenerbit(Penerbit penerbit)
        {
            _context.Penerbit.Add(penerbit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PenerbitExists(penerbit.KdPenerbit))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPenerbit", new { id = penerbit.KdPenerbit }, penerbit);
        }

        // DELETE: api/Penerbits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Penerbit>> DeletePenerbit(string id)
        {
            var penerbit = await _context.Penerbit.FindAsync(id);
            if (penerbit == null)
            {
                return NotFound();
            }

            _context.Penerbit.Remove(penerbit);
            await _context.SaveChangesAsync();

            return penerbit;
        }

        private bool PenerbitExists(string id)
        {
            return _context.Penerbit.Any(e => e.KdPenerbit == id);
        }
    }
}
