using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PerpustakaanAPI.Models
{
    public partial class DbPerpustakaanContext : DbContext
    {
        public DbPerpustakaanContext()
        {
        }

        public DbPerpustakaanContext(DbContextOptions<DbPerpustakaanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anggota> Anggota { get; set; }
        public virtual DbSet<Buku> Buku { get; set; }
        public virtual DbSet<DetailPinjam> DetailPinjam { get; set; }
        public virtual DbSet<Penerbit> Penerbit { get; set; }
        public virtual DbSet<Petugas> Petugas { get; set; }
        public virtual DbSet<Pinjam> Pinjam { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLOCALDB;Database=DbPerpustakaan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anggota>(entity =>
            {
                entity.HasKey(e => e.NoAnggota)
                    .HasName("PK__Anggota__60CF297985FDCBB3");

                entity.Property(e => e.NoAnggota)
                    .HasColumnName("No_Anggota")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Alamat)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin)
                    .IsRequired()
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NamaAnggota)
                    .IsRequired()
                    .HasColumnName("Nama_Anggota")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Buku>(entity =>
            {
                entity.HasKey(e => e.KdBuku)
                    .HasName("PK__Buku__3B24418961A3E89E");

                entity.Property(e => e.KdBuku)
                    .HasColumnName("Kd_Buku")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JudulBuku)
                    .IsRequired()
                    .HasColumnName("Judul_Buku")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KdPenerbit)
                    .IsRequired()
                    .HasColumnName("Kd_Penerbit")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pengarang)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetailPinjam>(entity =>
            {
                entity.HasKey(e => e.NoTrx)
                    .HasName("PK__Detail_P__591EA596AA9C7DB1");

                entity.ToTable("Detail_Pinjam");

                entity.Property(e => e.NoTrx)
                    .HasColumnName("No_Trx")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KdBuku)
                    .IsRequired()
                    .HasColumnName("Kd_Buku")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NoPinjam)
                    .IsRequired()
                    .HasColumnName("No_Pinjam")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Penerbit>(entity =>
            {
                entity.HasKey(e => e.KdPenerbit)
                    .HasName("PK__Penerbit__2B6769FD355DB388");

                entity.Property(e => e.KdPenerbit)
                    .HasColumnName("Kd_Penerbit")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AlamatPenerbit)
                    .IsRequired()
                    .HasColumnName("Alamat_Penerbit")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPenerbit)
                    .IsRequired()
                    .HasColumnName("Nama_Penerbit")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Petugas>(entity =>
            {
                entity.HasKey(e => e.IdPetugas)
                    .HasName("PK__Petugas__05F203053F7D864A");

                entity.Property(e => e.IdPetugas)
                    .HasColumnName("ID_Petugas")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JenisKelamin)
                    .IsRequired()
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NamaPetugas)
                    .IsRequired()
                    .HasColumnName("Nama_Petugas")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pinjam>(entity =>
            {
                entity.HasKey(e => e.NoPinjam)
                    .HasName("PK__Pinjam__2F39D4D548C06D1D");

                entity.Property(e => e.NoPinjam)
                    .HasColumnName("No_Pinjam")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdPetugas)
                    .IsRequired()
                    .HasColumnName("ID_Petugas")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NoAnggota)
                    .IsRequired()
                    .HasColumnName("No_Anggota")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TglKembali)
                    .HasColumnName("Tgl_kembali")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglPinjam)
                    .HasColumnName("Tgl_pinjam")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
