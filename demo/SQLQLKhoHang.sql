create database QLKhoHang;

create table LoaiSP(
	MaLoai char(10) not null primary key,
	TenLoai nchar(30),
	MotaLoaiSP nchar(1000)
)

create table NhanVien(
	MaNV char(30) not null primary key,
	TenNV nchar(30),
	ChucVu nchar,
	GioiTinh nchar(5),
	Sdt int,
	NgaySinh date,
	Luong money,
	DiaChi nvarchar(100),
	Email char(100)
)


create table SanPham(
	MaLoai char(10) not null foreign key references LoaiSP(MaLoai),
	MaSP char(10) not null primary key,
	TenSP nchar(30),
	SoLuong int,
	DonViTinh nchar(10),
	NgaySX date,
	HanSD date,
	Gia int,
	NhaCC nvarchar(30),
	MotaSP nvarchar(100)
)
create table NhapKho(
	MaPN char(10) not null primary key,
	MaNV char(30) not null foreign key references NhanVien(MaNV),
	NgayNhap date,
	MaLoai char(10) not null foreign key references LoaiSP(MaLoai),
	NhaCC nvarchar(30),
	SoLuongNhap int
)

create table XuatKho(
	MaPX char(30) not null primary key,
	MaNV char(30) not null foreign key references NhanVien(MaNV),
	NgayXuat date,
	MaLoai char(10) not null foreign key references LoaiSP(MaLoai),
	SoLuong int,
)

create table QuanLyTK(
	MaNV char(30) not null foreign key references NhanVien(MaNV),
	TenDN char(30) not null primary key,
	MK char(30),
	PhanQuyen nchar(10)
)
select * from SanPham;
Drop table SanPham;
