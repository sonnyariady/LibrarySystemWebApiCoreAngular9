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
    public class BukusController : ControllerBase
    {
        private readonly DbPerpustakaanContext _context;

        public BukusController(DbPerpustakaanContext context)
        {
            _context = context;
        }

        // GET: api/Bukus
        [HttpPost]
        public async Task<ActionResult<List<BukuViewModel>>> GetBuku()
        {
            List<BukuViewModel> lst = await (from b in _context.Buku
                                      join p in _context.Penerbit on b.KdPenerbit equals p.KdPenerbit
                                      orderby b.JudulBuku
                                      select new BukuViewModel
                                      {
                                          JudulBuku = b.JudulBuku.Trim(),
                                          KdBuku = b.KdBuku.Trim(),
                                          KdPenerbit = b.KdPenerbit.Trim(),
                                          Pengarang = b.Pengarang.Trim(),
                                          Nama_Penerbit = p.NamaPenerbit.Trim()
                                      }).ToListAsync();

            return lst;
        }

        // GET: api/Bukus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buku>> GetBuku(string id)
        {
            var buku = await _context.Buku.FindAsync(id);

            if (buku == null)
            {
                return NotFound();
            }

            return buku;
        }

        // PUT: api/Bukus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuku(string id, Buku buku)
        {
            if (id != buku.KdBuku)
            {
                return BadRequest();
            }

            _context.Entry(buku).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BukuExists(id))
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

        // POST: api/Bukus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Buku>> PostBuku(Buku buku)
        {
            _context.Buku.Add(buku);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BukuExists(buku.KdBuku))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuku", new { id = buku.KdBuku }, buku);
        }

        // DELETE: api/Bukus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Buku>> DeleteBuku(string id)
        {
            var buku = await _context.Buku.FindAsync(id);
            if (buku == null)
            {
                return NotFound();
            }

            _context.Buku.Remove(buku);
            await _context.SaveChangesAsync();

            return buku;
        }

        private bool BukuExists(string id)
        {
            return _context.Buku.Any(e => e.KdBuku == id);
        }
    }
}
