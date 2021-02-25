using PerpustakaanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerpustakaanAPI.ViewModels
{
    public class PinjamViewModel
    {
        public string NoPinjam { get; set; }
        public string IdPetugas { get; set; }
        public string NoAnggota { get; set; }
        public string TglPinjam { get; set; }
        public string TglKembali { get; set; }

        public string NamaPetugas { get; set; }

        public string NamaAnggota { get; set; }

        public List<BukuViewModel> DetailPinjam { get; set; }

        public PinjamViewModel()
        {

        }

        public void ExtractHeaderFromEntity(Pinjam entityheader)
        {
            this.IdPetugas = entityheader.IdPetugas.Trim();
            this.NoPinjam = entityheader.NoPinjam.Trim();
            this.NoAnggota = entityheader.NoAnggota.Trim();
            this.TglKembali = entityheader.TglKembali == null ? string.Empty : entityheader.TglKembali.Value.ToString("yyyyMMdd");
            this.TglPinjam = entityheader.TglPinjam.ToString("yyyyMMdd");
        }

        public Pinjam toEntity()
        {
            Pinjam pinjam = new Pinjam();
            pinjam.NoPinjam = this.NoPinjam;
            pinjam.IdPetugas = this.IdPetugas;
            pinjam.NoAnggota = this.NoAnggota;

            int strYear = Convert.ToInt32(TglPinjam.Substring(0, 4));
            int strMonth = Convert.ToInt32(TglPinjam.Substring(4, 2));
            int strDay = Convert.ToInt32(TglPinjam.Substring(6, 2));
            pinjam.TglPinjam = new DateTime(strYear, strMonth, strDay);

            if (!string.IsNullOrEmpty(TglKembali))
            {
                strYear = Convert.ToInt32(TglKembali.Substring(0, 4));
                strMonth = Convert.ToInt32(TglKembali.Substring(4, 2));
                strDay = Convert.ToInt32(TglKembali.Substring(6, 2));
                pinjam.TglKembali = new DateTime(strYear, strMonth, strDay);
            }
            else
                pinjam.TglKembali = null;

            return pinjam;
        }

    }
}
