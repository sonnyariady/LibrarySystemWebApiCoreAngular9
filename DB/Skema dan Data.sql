/****** Object:  Table [dbo].[UserLogin]    Script Date: 2/25/2021 4:37:55 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[UserLogin]
GO
/****** Object:  Table [dbo].[Pinjam]    Script Date: 2/25/2021 4:37:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pinjam]') AND type in (N'U'))
DROP TABLE [dbo].[Pinjam]
GO
/****** Object:  Table [dbo].[Petugas]    Script Date: 2/25/2021 4:37:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Petugas]') AND type in (N'U'))
DROP TABLE [dbo].[Petugas]
GO
/****** Object:  Table [dbo].[Penerbit]    Script Date: 2/25/2021 4:37:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Penerbit]') AND type in (N'U'))
DROP TABLE [dbo].[Penerbit]
GO
/****** Object:  Table [dbo].[Detail_Pinjam]    Script Date: 2/25/2021 4:37:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Detail_Pinjam]') AND type in (N'U'))
DROP TABLE [dbo].[Detail_Pinjam]
GO
/****** Object:  Table [dbo].[Buku]    Script Date: 2/25/2021 4:37:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buku]') AND type in (N'U'))
DROP TABLE [dbo].[Buku]
GO
/****** Object:  Table [dbo].[Anggota]    Script Date: 2/25/2021 4:37:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Anggota]') AND type in (N'U'))
DROP TABLE [dbo].[Anggota]
GO
/****** Object:  Table [dbo].[Anggota]    Script Date: 2/25/2021 4:37:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anggota](
	[No_Anggota] [char](10) NOT NULL,
	[Nama_Anggota] [varchar](30) NOT NULL,
	[Jenis_Kelamin] [char](1) NOT NULL,
	[Alamat] [varchar](30) NOT NULL,
	[Telp] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[No_Anggota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buku]    Script Date: 2/25/2021 4:37:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buku](
	[Kd_Buku] [char](10) NOT NULL,
	[Kd_Penerbit] [char](10) NOT NULL,
	[Judul_Buku] [varchar](30) NOT NULL,
	[Pengarang] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Kd_Buku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detail_Pinjam]    Script Date: 2/25/2021 4:37:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_Pinjam](
	[No_Trx] [char](10) NOT NULL,
	[No_Pinjam] [char](10) NOT NULL,
	[Kd_Buku] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[No_Trx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Penerbit]    Script Date: 2/25/2021 4:37:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Penerbit](
	[Kd_Penerbit] [char](10) NOT NULL,
	[Nama_Penerbit] [varchar](30) NOT NULL,
	[Alamat_Penerbit] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Kd_Penerbit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Petugas]    Script Date: 2/25/2021 4:37:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Petugas](
	[ID_Petugas] [char](30) NOT NULL,
	[Nama_Petugas] [varchar](30) NOT NULL,
	[Jenis_Kelamin] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Petugas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pinjam]    Script Date: 2/25/2021 4:37:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pinjam](
	[No_Pinjam] [char](10) NOT NULL,
	[ID_Petugas] [char](10) NOT NULL,
	[No_Anggota] [char](10) NOT NULL,
	[Tgl_pinjam] [datetime] NOT NULL,
	[Tgl_kembali] [datetime] NULL,
 CONSTRAINT [PK__Pinjam__2F39D4D548C06D1D] PRIMARY KEY CLUSTERED 
(
	[No_Pinjam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 2/25/2021 4:37:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0001    ', N'Julianto', N'L', N'Kp. Utan', 81212124231)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0002    ', N'Markimun', N'L', N'Tangerang', 8154525678)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0003    ', N'M. Muslim', N'L', N'Ciputat', 8213457895)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0004    ', N'Nisa Umar', N'P', N'Pamulang C4', 6656657)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0005    ', N'Anis Rida Sari', N'P', N'Sepatan', 8129468765)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0006    ', N'Lukman Ahmad', N'L', N'Depok', 81378656454)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0007    ', N'Imam Sunaryo', N'L', N'Jakarta', 81229988454)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0008    ', N'Handayati', N'P', N'Tangerang', 8228763452)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0009    ', N'Yonathan', N'L', N'Serpong', 819568745)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0010    ', N'Mawar Siregar', N'P', N'Tiga Raksa', 81376837737)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0011    ', N'Abdul Johar Kadir', N'L', N'Jalan Kenanga 2B', 123456)
GO
INSERT [dbo].[Anggota] ([No_Anggota], [Nama_Anggota], [Jenis_Kelamin], [Alamat], [Telp]) VALUES (N'A_0012    ', N'Vinessa Mariani', N'P', N'Jalan Jagung', 998998)
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0001    ', N'Pen0001   ', N'R (Raja, Ratu, Rahasia)', N'Wulan Fadli')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0002    ', N'Pen0002   ', N'Sepotong Senja Untuk Pacarku', N'Seno Gumira Ajudarma')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0003    ', N'Pen0003   ', N'My Stupid Boss 5', N'Chaos @Work')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0004    ', N'Pen0001   ', N'Dear Nathan', N'Erisca Febriani')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0005    ', N'Pen0002   ', N'Bumi', N'Tere Liye')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0006    ', N'Pen0004   ', N'Dilan 1990', N'Pidi Baiq')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0007    ', N'Pen0002   ', N'Hujan Bulan Juni', N'Sapardi Djoko Damono')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0008    ', N'Pen0002   ', N'Crfitical Eleven', N'Ika Natassa')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0009    ', N'Pen0005   ', N'Hujan', N'Tere Liye')
GO
INSERT [dbo].[Buku] ([Kd_Buku], [Kd_Penerbit], [Judul_Buku], [Pengarang]) VALUES (N'B_0010    ', N'Pen0006   ', N'Asmara Loka', N'Danarto')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00001    ', N'00001     ', N'B_0001    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00002    ', N'00001     ', N'B_0005    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00003    ', N'00001     ', N'B_0006    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00004    ', N'00002     ', N'B_0010    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00005    ', N'00003     ', N'B_0007    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00006    ', N'00003     ', N'B_0008    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00007    ', N'00004     ', N'B_0009    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00008    ', N'00004     ', N'B_0002    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00009    ', N'00005     ', N'B_0001    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00010    ', N'00005     ', N'B_0004    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00011    ', N'00006     ', N'B_0010    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00012    ', N'00006     ', N'B_0007    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00013    ', N'00007     ', N'B_0003    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00014    ', N'00007     ', N'B_0004    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00015    ', N'00008     ', N'B_0006    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00016    ', N'00008     ', N'B_0008    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00017    ', N'00009     ', N'B_0007    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00018    ', N'00009     ', N'B_0010    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00019    ', N'00009     ', N'B_0003    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00020    ', N'00010     ', N'B_0002    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00021    ', N'00012     ', N'B_0008    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00022    ', N'00013     ', N'B_0002    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00023    ', N'00013     ', N'B_0003    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00024    ', N'00014     ', N'B_0008    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00025    ', N'00014     ', N'B_0005    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00026    ', N'00015     ', N'B_0006    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00027    ', N'00016     ', N'B_0009    ')
GO
INSERT [dbo].[Detail_Pinjam] ([No_Trx], [No_Pinjam], [Kd_Buku]) VALUES (N'T00028    ', N'00016     ', N'B_0007    ')
GO
INSERT [dbo].[Penerbit] ([Kd_Penerbit], [Nama_Penerbit], [Alamat_Penerbit]) VALUES (N'Pen0001   ', N'Best Media', N'Jakarta')
GO
INSERT [dbo].[Penerbit] ([Kd_Penerbit], [Nama_Penerbit], [Alamat_Penerbit]) VALUES (N'Pen0002   ', N'PT. Gramedia Pustaka Utama', N'Jakarta')
GO
INSERT [dbo].[Penerbit] ([Kd_Penerbit], [Nama_Penerbit], [Alamat_Penerbit]) VALUES (N'Pen0003   ', N'Gradien Mediatama', N'Jakarta')
GO
INSERT [dbo].[Penerbit] ([Kd_Penerbit], [Nama_Penerbit], [Alamat_Penerbit]) VALUES (N'Pen0004   ', N'Pastel Book', N'Bandung')
GO
INSERT [dbo].[Penerbit] ([Kd_Penerbit], [Nama_Penerbit], [Alamat_Penerbit]) VALUES (N'Pen0005   ', N'Republika', N'Jakarta')
GO
INSERT [dbo].[Penerbit] ([Kd_Penerbit], [Nama_Penerbit], [Alamat_Penerbit]) VALUES (N'Pen0006   ', N'Diva Press', N'Surabaya')
GO
INSERT [dbo].[Petugas] ([ID_Petugas], [Nama_Petugas], [Jenis_Kelamin]) VALUES (N'P_0001                        ', N'Andre Simatupang', N'P')
GO
INSERT [dbo].[Petugas] ([ID_Petugas], [Nama_Petugas], [Jenis_Kelamin]) VALUES (N'P_0002                        ', N'Benny Gunawan', N'P')
GO
INSERT [dbo].[Petugas] ([ID_Petugas], [Nama_Petugas], [Jenis_Kelamin]) VALUES (N'P_0003                        ', N'Dewi Apriani', N'L')
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00001     ', N'P_0001    ', N'A_0001    ', CAST(N'2017-03-15T00:00:00.000' AS DateTime), CAST(N'2017-03-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00003     ', N'P_0002    ', N'A_0003    ', CAST(N'2017-03-15T00:00:00.000' AS DateTime), CAST(N'2017-03-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00004     ', N'P_0003    ', N'A_0005    ', CAST(N'2017-03-20T00:00:00.000' AS DateTime), CAST(N'2017-03-25T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00005     ', N'P_0001    ', N'A_0007    ', CAST(N'2017-03-21T00:00:00.000' AS DateTime), CAST(N'2017-03-26T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00006     ', N'P_0003    ', N'A_0009    ', CAST(N'2017-03-24T00:00:00.000' AS DateTime), CAST(N'2017-03-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00007     ', N'P_0002    ', N'A_0006    ', CAST(N'2017-03-24T00:00:00.000' AS DateTime), CAST(N'2017-03-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00008     ', N'P_0003    ', N'A_0008    ', CAST(N'2017-04-01T00:00:00.000' AS DateTime), CAST(N'2017-04-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00009     ', N'P_0002    ', N'A_0004    ', CAST(N'2017-04-03T00:00:00.000' AS DateTime), CAST(N'2017-04-08T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00010     ', N'P_0002    ', N'A_0010    ', CAST(N'2017-04-10T00:00:00.000' AS DateTime), CAST(N'2017-04-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00011     ', N'P_0002    ', N'A_0006    ', CAST(N'2021-02-24T00:00:00.000' AS DateTime), CAST(N'2021-02-27T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00012     ', N'P_0002    ', N'A_0008    ', CAST(N'2021-02-19T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00013     ', N'P_0001    ', N'A_0006    ', CAST(N'2021-02-17T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00014     ', N'P_0002    ', N'A_0002    ', CAST(N'2021-02-25T00:00:00.000' AS DateTime), CAST(N'2021-03-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00015     ', N'P_0002    ', N'A_0007    ', CAST(N'2021-02-21T00:00:00.000' AS DateTime), CAST(N'2021-02-28T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Pinjam] ([No_Pinjam], [ID_Petugas], [No_Anggota], [Tgl_pinjam], [Tgl_kembali]) VALUES (N'00016     ', N'P_0001    ', N'A_0009    ', CAST(N'2021-02-24T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[UserLogin] ([UserId], [Password]) VALUES (N'P_0001', N'12345')
GO
INSERT [dbo].[UserLogin] ([UserId], [Password]) VALUES (N'P_0002', N'12345')
GO
INSERT [dbo].[UserLogin] ([UserId], [Password]) VALUES (N'P_0003', N'12345')
GO
