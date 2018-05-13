USE [SanSachCu]
GO
/****** Object:  Table [dbo].[BaiDang]    Script Date: 5/12/2018 9:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiDang](
	[ma] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[gioithieu] [nvarchar](100) NOT NULL,
	[ngaydang] [date] NOT NULL,
	[giodang] [time](7) NOT NULL,
	[trangthai] [int] NOT NULL,
	[gia] [int] NOT NULL,
	[tinhtrang] [bit] NOT NULL,
	[matacgia] [int] NOT NULL,
	[matheloai] [int] NOT NULL,
	[manxb] [int] NOT NULL,
	[mataikhoan] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 5/12/2018 9:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[ma] [int] IDENTITY(1,1) NOT NULL,
	[ngaygiao] [date] NOT NULL,
	[tinhtrang] [bit] NOT NULL,
	[mataikhoan] [int] NOT NULL,
	[masach] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 5/12/2018 9:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[ma] [int] IDENTITY(1,1) NOT NULL,
	[tennhaxuatban] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 5/12/2018 9:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[ma] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[gioithieu] [nvarchar](200) NOT NULL,
	[ngaydang] [date] NOT NULL,
	[giodang] [time](7) NOT NULL,
	[trangthai] [int] NOT NULL,
	[gia] [int] NOT NULL,
	[tinhtrang] [bit] NOT NULL,
	[matacgia] [int] NOT NULL,
	[manxb] [int] NOT NULL,
	[matheloai] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 5/12/2018 9:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[ma] [int] IDENTITY(1,1) NOT NULL,
	[tentacgia] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/12/2018 9:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ma] [int] IDENTITY(1,1) NOT NULL,
	[matkhau] [nvarchar](50) NOT NULL,
	[hoten] [nvarchar](50) NOT NULL,
	[ngaysinh] [date] NOT NULL,
	[diachi] [nvarchar](50) NOT NULL,
	[tendangnhap] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tendangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 5/12/2018 9:12:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[ma] [int] IDENTITY(1,1) NOT NULL,
	[tenloaisach] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaiDang] ADD  DEFAULT ((0)) FOR [tinhtrang]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT ((0)) FOR [tinhtrang]
GO
ALTER TABLE [dbo].[Sach] ADD  DEFAULT ((0)) FOR [tinhtrang]
GO
ALTER TABLE [dbo].[BaiDang]  WITH CHECK ADD FOREIGN KEY([manxb])
REFERENCES [dbo].[NhaXuatBan] ([ma])
GO
ALTER TABLE [dbo].[BaiDang]  WITH CHECK ADD FOREIGN KEY([matacgia])
REFERENCES [dbo].[TacGia] ([ma])
GO
ALTER TABLE [dbo].[BaiDang]  WITH CHECK ADD FOREIGN KEY([mataikhoan])
REFERENCES [dbo].[TaiKhoan] ([ma])
GO
ALTER TABLE [dbo].[BaiDang]  WITH CHECK ADD FOREIGN KEY([matheloai])
REFERENCES [dbo].[TheLoai] ([ma])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([masach])
REFERENCES [dbo].[Sach] ([ma])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([mataikhoan])
REFERENCES [dbo].[TaiKhoan] ([ma])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([manxb])
REFERENCES [dbo].[NhaXuatBan] ([ma])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([matacgia])
REFERENCES [dbo].[TacGia] ([ma])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([matheloai])
REFERENCES [dbo].[TheLoai] ([ma])
GO
