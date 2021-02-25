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
    public class DetailPinjamsController : ControllerBase
    {
        private readonly DbPerpustakaanContext _context;

        public DetailPinjamsController(DbPerpustakaanContext context)
        {
            _context = context;
        }

        // GET: api/DetailPinjams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailPinjam>>> GetDetailPinjam()
        {
            return await _context.DetailPinjam.ToListAsync();
        }

        // GET: api/DetailPinjams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailPinjam>> GetDetailPinjam(string id)
        {
            var detailPinjam = await _context.DetailPinjam.FindAsync(id);

            if (detailPinjam == null)
            {
                return NotFound();
            }

            return detailPinjam;
        }

        // PUT: api/DetailPinjams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailPinjam(string id, DetailPinjam detailPinjam)
        {
            if (id != detailPinjam.NoTrx)
            {
                return BadRequest();
            }

            _context.Entry(detailPinjam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailPinjamExists(id))
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

        // POST: api/DetailPinjams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetailPinjam>> PostDetailPinjam(DetailPinjam detailPinjam)
        {
            _context.DetailPinjam.Add(detailPinjam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetailPinjamExists(detailPinjam.NoTrx))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetailPinjam", new { id = detailPinjam.NoTrx }, detailPinjam);
        }

        // DELETE: api/DetailPinjams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetailPinjam>> DeleteDetailPinjam(string id)
        {
            var detailPinjam = await _context.DetailPinjam.FindAsync(id);
            if (detailPinjam == null)
            {
                return NotFound();
            }

            _context.DetailPinjam.Remove(detailPinjam);
            await _context.SaveChangesAsync();

            return detailPinjam;
        }

        private bool DetailPinjamExists(string id)
        {
            return _context.DetailPinjam.Any(e => e.NoTrx == id);
        }
    }
}
