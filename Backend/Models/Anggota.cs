using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PerpustakaanAPI.Models
{
    public partial class Anggota
    {
        public string NoAnggota { get; set; }
        public string NamaAnggota { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public long Telp { get; set; }
    }
}
