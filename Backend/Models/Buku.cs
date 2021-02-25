using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PerpustakaanAPI.Models
{
    public partial class Buku
    {
        public string KdBuku { get; set; }
        public string KdPenerbit { get; set; }
        public string JudulBuku { get; set; }
        public string Pengarang { get; set; }
    }
}
