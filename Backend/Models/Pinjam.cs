using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PerpustakaanAPI.Models
{
    public partial class Pinjam
    {
        public string NoPinjam { get; set; }
        public string IdPetugas { get; set; }
        public string NoAnggota { get; set; }
        public DateTime TglPinjam { get; set; }
        public DateTime? TglKembali { get; set; }
    }
}
