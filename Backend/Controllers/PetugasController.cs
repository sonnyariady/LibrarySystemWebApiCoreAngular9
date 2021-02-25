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
    public class PetugasController : ControllerBase
    {
        private readonly DbPerpustakaanContext _context;

        public PetugasController(DbPerpustakaanContext context)
        {
            _context = context;
        }

        // GET: api/Petugas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Petugas>>> GetPetugas()
        {
            return await _context.Petugas.ToListAsync();
        }

        // GET: api/Petugas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Petugas>> GetPetugas(string id)
        {
            var petugas = await _context.Petugas.FindAsync(id);

            if (petugas == null)
            {
                return NotFound();
            }

            return petugas;
        }

        // PUT: api/Petugas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetugas(string id, Petugas petugas)
        {
            if (id != petugas.IdPetugas)
            {
                return BadRequest();
            }

            _context.Entry(petugas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetugasExists(id))
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

        // POST: api/Petugas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Petugas>> PostPetugas(Petugas petugas)
        {
            _context.Petugas.Add(petugas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PetugasExists(petugas.IdPetugas))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPetugas", new { id = petugas.IdPetugas }, petugas);
        }

        // DELETE: api/Petugas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Petugas>> DeletePetugas(string id)
        {
            var petugas = await _context.Petugas.FindAsync(id);
            if (petugas == null)
            {
                return NotFound();
            }

            _context.Petugas.Remove(petugas);
            await _context.SaveChangesAsync();

            return petugas;
        }

        private bool PetugasExists(string id)
        {
            return _context.Petugas.Any(e => e.IdPetugas == id);
        }
    }
}
