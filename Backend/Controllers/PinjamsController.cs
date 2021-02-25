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
    public class PinjamsController : ControllerBase
    {
        private readonly DbPerpustakaanContext _context;

        public PinjamsController(DbPerpustakaanContext context)
        {
            _context = context;
        }

        // GET: api/Pinjams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pinjam>>> GetPinjam()
        {
            return await _context.Pinjam.ToListAsync();
        }

        // GET: api/Pinjams
        [HttpPost]
        public async Task<ActionResult<List<PinjamViewModel>>> GetPinjamList()
        {
            List<PinjamViewModel> list = new List<PinjamViewModel>();
            try
            {
                list = await (from pj in _context.Pinjam
                              join ptg in _context.Petugas on pj.IdPetugas equals ptg.IdPetugas
                              join agt in _context.Anggota on pj.NoAnggota equals agt.NoAnggota
                              orderby pj.NoPinjam descending
                              select new PinjamViewModel
                              {
                                  IdPetugas = pj.IdPetugas,
                                  NoAnggota = pj.NoAnggota,
                                  NoPinjam = pj.NoPinjam,
                                  TglPinjam = pj.TglPinjam.ToString("dd-MMM-yyyy"),
                                  TglKembali = pj.TglKembali == null ? string.Empty : pj.TglKembali.Value.ToString("dd-MMM-yyyy"),
                                  NamaAnggota = agt.NamaAnggota,
                                  NamaPetugas = ptg.NamaPetugas
                              }).ToListAsync();

            }
            catch (Exception ex)
            {

               
            }
            return list;
        }

        private async Task<string> GenerateId()
        {
            string maxId = await _context.Pinjam.Select(a => a.NoPinjam).MaxAsync();
            int intmaxid = Convert.ToInt32(maxId);
            intmaxid++;
            // int panjang = 5;
            string newid = FormatDigit(5, intmaxid);
            
            return newid;
        }

        private async Task<int> GetMaxSeqId()
        {
            string maxId = await _context.DetailPinjam.Select(a => a.NoTrx).MaxAsync();
            int intmaxid = Convert.ToInt32(maxId.Replace("T",""));
            
            return intmaxid;
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

        // GET: api/Pinjams
        [HttpPost]
        public async Task<ActionResult<string>> GetNewId()
        {

            string newid = await GenerateId();


            return newid;
        }

        // GET: api/Pinjams/5
       [HttpPost]
        public async Task<ActionResult<PinjamViewModel>> GetPinjamById(string id)
        {
            PinjamViewModel pinjamView = new PinjamViewModel();

            try
            {

                var pinjam = await _context.Pinjam.FindAsync(id);

                if (pinjam == null)
                {
                    return null;
                }

                List< BukuViewModel> listdetpinjam = await (from dp in _context.DetailPinjam
                                join b in _context.Buku on dp.KdBuku equals b.KdBuku
                                join p in _context.Penerbit on b.KdPenerbit equals p.KdPenerbit
                                where dp.NoPinjam == id
                                select new BukuViewModel
                                {
                                    JudulBuku = b.JudulBuku.Trim(),
                                    KdBuku = b.KdBuku.Trim(),
                                    KdPenerbit = b.KdPenerbit.Trim(),
                                    Pengarang = b.Pengarang.Trim(),
                                    Nama_Penerbit = p.NamaPenerbit.Trim()
                                }).ToListAsync();

                pinjamView.ExtractHeaderFromEntity(pinjam);
                pinjamView.DetailPinjam = listdetpinjam;
 
            } catch (Exception ex)
            {

            }

            return pinjamView;
        }

        // PUT: api/Pinjams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPinjam(string id, Pinjam pinjam)
        {
            if (id != pinjam.NoPinjam)
            {
                return BadRequest();
            }

            _context.Entry(pinjam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PinjamExists(id))
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

        // POST: api/Pinjams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PinjamViewModel pinjam)
        {
            PostCommandResult result = new PostCommandResult();
            pinjam.NoPinjam = await GenerateId();
            _context.Pinjam.Add(pinjam.toEntity());
            try
            {
                //tambah juga detailnya
                int getmax = await GetMaxSeqId();
                foreach (var item in pinjam.DetailPinjam)
                {
                    getmax++;
                    DetailPinjam detailPinjam = new DetailPinjam();
                    detailPinjam.NoTrx = "T" + FormatDigit(5, getmax);
                    detailPinjam.KdBuku = item.KdBuku;
                    detailPinjam.NoPinjam = pinjam.NoPinjam;
                    _context.DetailPinjam.Add(detailPinjam);
                }


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
        public async Task<IActionResult> Update([FromBody] PinjamViewModel pinjam)
        {
            PostCommandResult result = new PostCommandResult();

            _context.Entry(pinjam.toEntity()).State = EntityState.Modified;
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

        // DELETE: api/Pinjams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pinjam>> DeletePinjam(string id)
        {
            var pinjam = await _context.Pinjam.FindAsync(id);
            if (pinjam == null)
            {
                return NotFound();
            }

            _context.Pinjam.Remove(pinjam);
            await _context.SaveChangesAsync();

            return pinjam;
        }

        private bool PinjamExists(string id)
        {
            return _context.Pinjam.Any(e => e.NoPinjam == id);
        }
    }
}
