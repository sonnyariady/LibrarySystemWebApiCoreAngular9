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
    public class AnggotasController : ControllerBase
    {
        private readonly DbPerpustakaanContext _context;

        public AnggotasController(DbPerpustakaanContext context)
        {
            _context = context;
        }

        // GET: api/Anggotas
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Anggota>>> GetAnggota()
        {
            return await _context.Anggota.OrderBy(a=> a.NamaAnggota.Trim()).ToListAsync();
        }

        // GET: api/Anggotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anggota>> GetAnggota(string id)
        {
            var anggota = await _context.Anggota.FindAsync(id);

            if (anggota == null)
            {
                return NotFound();
            }

            return anggota;
        }

        // PUT: api/Anggotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnggota(string id, Anggota anggota)
        {
            if (id != anggota.NoAnggota)
            {
                return BadRequest();
            }

            _context.Entry(anggota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnggotaExists(id))
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

        private string FormatDigit(int jmldigit, int angka)
        {
            string newid = angka.ToString();
            int kurang0 = jmldigit - newid.Length;
            for (int i = 0; i < kurang0; i++)
            {
                newid = "0" + newid;
            }
            return newid;
        }

        private async Task<string> GenerateId()
        {
            string maxId = await _context.Anggota.Select(a => a.NoAnggota).MaxAsync();
            int intmaxid = Convert.ToInt32(maxId);
            intmaxid++;
            // int panjang = 5;
            string newid = FormatDigit(4, intmaxid);

            return newid;
        }

        private async Task<int> GetMaxSeqId()
        {
            string maxId = await _context.Anggota.Select(a => a.NoAnggota).MaxAsync();
            int intmaxid = Convert.ToInt32(maxId.Replace("A_", ""));

            return intmaxid;
        }

        // POST: api/Anggotas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Anggota>> Insert(Anggota anggota)
        {
            PostCommandResult result = new PostCommandResult();
            int getmaxID = await GetMaxSeqId();
            getmaxID++;
            anggota.NoAnggota = "A_" + FormatDigit(4, getmaxID);
            _context.Anggota.Add(anggota);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                result.ErrorMessage = ex.Message;
                result.IsSuccess = false;
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Anggota>> Update(Anggota anggota)
        {
            PostCommandResult result = new PostCommandResult();

            _context.Entry(anggota).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.IsSuccess = false;
            }

            return Ok(result);
        }

        // DELETE: api/Anggotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Anggota>> DeleteAnggota(string id)
        {
            var anggota = await _context.Anggota.FindAsync(id);
            if (anggota == null)
            {
                return NotFound();
            }

            _context.Anggota.Remove(anggota);
            await _context.SaveChangesAsync();

            return anggota;
        }

        private bool AnggotaExists(string id)
        {
            return _context.Anggota.Any(e => e.NoAnggota == id);
        }
    }
}
