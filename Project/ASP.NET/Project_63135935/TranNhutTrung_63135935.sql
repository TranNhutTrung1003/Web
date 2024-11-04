create database Project_63135935
go
use Project_63135935
go

create table LoaiSach
(
	MaLoaiSach char(6) primary key
	, TenLoaiSach nvarchar(50) 
)

create table Sach
(
	MaSach char(6) primary key
	, MaLoaiSach char(6) not null foreign key references LoaiSach(MaLoaiSach)
	, TenSach nvarchar(70)
	, AnhSach nvarchar(50)
	, DonGia int
	, TacGia nvarchar(50)
	, NhaXuatBan nvarchar(50)
	, Mota nvarchar(200) 
	, NgayXuatBan date
)

create table KhachHang
(
	MaKH char(6) primary key
	, HoKH nvarchar(50) not null
	, TenKH nvarchar(50) not null
	, DiaChi nvarchar(60) not null
	, SoDT varchar(15)
	, NgaySinh date
	, GioiTinh bit default(1)
	, Email varchar(40) not null unique
	, MatKhau varchar(40) not null
)

create table Chucvu
(
	MaCV char(6) primary key
	, tenchucvu nvarchar(60) not null
)

create table NhanVien
(
	MaNV char(6) primary key
	, HoNV nvarchar(50) not null
	, TenNV nvarchar(50) not null
	, SoDT varchar(15)
	, Email varchar(40) not null unique
	, GioiTinh bit
	, DiaChi nvarchar(60)
	, Matkhau varchar(60) not null
	, Ma_CV char(6) not null foreign key references Chucvu(MaCV)
	, ngaysinh date
)

create table GioHang
(
	MaDH char(6) primary key
	, NgayDat date
	, MaKH char(6) not null foreign key references KhachHang(MaKH)
	, MaNV char(6) foreign key references NhanVien(MaNV)
	, Sodt varchar(15)
	, Diachigiaohang nvarchar(100)
	, Email varchar(50)
	, DuyetDH bit default(0)
)

create table ChiTietGioHang
(
	MaCTGH char(6) primary key
	, MaDH char(6) not null foreign key references GioHang(MaDH)
	, MaSach char(6) not null foreign key references Sach(MaSach)
	, SoLuong int not null
	, ThanhTien decimal(18,2) not null
	, GiaBan decimal(18,2) not null
)

insert into LoaiSach values('MLS001', N'Tiếng Anh')
insert into LoaiSach values('MLS002', N'Ngữ Văn')
insert into LoaiSach values('MLS003', N'Tiểu thuyết Tình Cảm')
insert into LoaiSach values('MLS004', N'Khoa Học Viễn Tưởng')
insert into LoaiSach values('MLS005', N'Light Novel')
insert into LoaiSach values('MLS006', N'Kinh Dị')
insert into LoaiSach values('MLS007', N'Hành Động')
insert into LoaiSach values('MLS008', N'Lập Trình')
insert into LoaiSach values('MLS009', N'Trinh Thám')

insert into Chucvu values('MCV001', 'admin')
insert into Chucvu values('MCV002', 'shipper')

insert into Sach values('MSS001', 'MLS001', 'Basic English Grammar', 'sach01.jpg', '300000', 'Betty Schrampfer Azar', 'Pearson: Pearson', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'2003-11-23' AS Date))
insert into Sach values('MSS002', 'MLS003', N'Tình yêu thời thổ tả', 'sach02.jpg', '500000', N'Gabriel García Márquez', N'Văn Học', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'2003-11-25' AS Date))
insert into Sach values('MSS003', 'MLS004', 'Solaris', 'sach03.jpg', '420000', ' Stanislaw Lem', N'Leningrat', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS004', 'MLS001', 'English Grammar in Use Book w Ans', 'sach04.jpg', '420000', ' Raymond Murphy', N'Cambridge University', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS005', 'MLS001', 'Grammar For You (Basic)', 'sach05.jpg', '420000', N'Dương Hương', N'NXB Đại Học Quốc Gia Hà Nội', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS006', 'MLS001', 'Speak English like an American', 'sach06.jpg', '420000', N'Amy Gillet', N'NXB Đại Học Quốc Gia Hà Nội', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS007', 'MLS001', N'Vừa lười vừa bận vẫn giỏi tiếng anh', 'sach07.jpg', '420000', N'Amy Gillet', N'NXB Đại Học Quốc Gia Hà Nội', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS008', 'MLS003', N'Nhật ký', 'sach08.jpg', '420000', 'Nicholas Sparks', N'NXB Đại Học Quốc Gia Hà Nội', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS009', 'MLS005', N'Và Rồi, Tháng 9 Không Có Cậu Đã Tới', 'sach09.jpg', '420000', 'Natsuki Amasawa', N'NXB Thế Giới', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS010', 'MLS002', N'Ngữ văn 6', 'sach10.jpg', '420000', N'Kim Lân', N'NXB Thế Giới', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS011', 'MLS002', N'Ngữ văn 11', 'sach11.jpg', '420000', N'Kim Lân', N'NXB Thế Giới', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS012', 'MLS004', N'Người máy có mơ về cừu điện không?', 'sach12.jpg', '420000', N'Philip K. Dick', N'NXB Thế Giới', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS013', 'MLS004', N'Tam Thể', 'sach13.jpg', '420000', N'Lưu Từ Hân', N'NXB Thế Giới', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS014', 'MLS006', N'Ngủ Cùng Người Chết', 'sach14.jpg', '420000', N'Thảo Trang', N'NXB Thế Giới', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS015', 'MLS006', N'Tết ở làng Địa Ngục', 'sach15.jpg', '420000', N'Thảo Trang', N'NXB Thế Giới', N'Cuộc sống tất bật ngày nay dễ khiến người ta sợ cảm giác bị bỏ lại phía sau.', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS016', 'MLS006', N'Dracula', 'sach16.jpg', '420000', N'Bram Stoker', N'NXB Thế Giới', N'Tác phẩm mở đầu với cảnh luật sư Jonathan Harker đi công tác và ở tại một lâu đài của một quý tộc Transilvania, Bá tước Dracula', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS017', 'MLS005', N'86 - Eighty Six - Tập 1', 'sach17.jpg', '420000', N'Asato Asato', N'NXB Thế Giới', N'Tác phẩm mở đầu với cảnh luật sư Jonathan Harker', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS018', 'MLS005', N'Re: Zero − Bắt đầu lại ở thế giới khác - Tập 6', 'sach18.jpg', '420000', N'Tappei Nagatsuki', N'NXB Thế Giới', N'Tác phẩm mở đầu với cảnh luật sư Jonathan Harker', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS019', 'MLS009', N'Mật mã Da Vinci', 'sach19.jpg', '420000', N'Dan Brown', N'NXB Thế Giới', N'Tác phẩm mở đầu với cảnh luật sư Jonathan Harker', CAST(N'1981-3-15' AS Date))
insert into Sach values('MSS020', 'MLS009', N'Án mạng trên sông Nile', 'sach20.jpg', '420000', N'Agatha Christie', N'NXB Thế Giới', N'Tác phẩm mở đầu với cảnh luật sư Jonathan Harker', CAST(N'1981-3-15' AS Date))


insert into KhachHang values('MKH001', N'Nguyễn Hồ Minh', N'Thạnh', N'Nha Trang - Khánh Hòa', '0898753560', CAST(N'2003-11-23' AS Date), 0, 'thanh.nhm.63cntt@ntu.edu.vn', 'thanh#256')
insert into KhachHang values('MKH002', N'Nguyễn Phúc', N'Sỹ', N'25 Trần Phú', '0898753560', CAST(N'2003-11-23' AS Date), 0, 'sy.np.63cntt@ntu.edu.vn', 'sy#256')
insert into KhachHang values('MKH003', N'Nguyễn Phúc', N'Tuyên', N'26 Trần Phú', '0898753560', CAST(N'2003-11-23' AS Date), 0, 'tuyen.np.63cntt@ntu.edu.vn', 'tuyen#256')
insert into KhachHang values('MKH004', N'Nguyễn Trương', N'Tuyên', N'26 Trần Phú', '0898753560', CAST(N'2003-11-23' AS Date), 1, 'tuyen.nt.63cntt@ntu.edu.vn', 'truongtuyen#256')
insert into KhachHang values('MKH005', N'Nguyễn Trương', N'Sỹ', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-23' AS Date), 1, 'sy.nt.63cntt@ntu.edu.vn', 'truongsy#256')
insert into KhachHang values('MKH006', N'Nguyễn Phúc', N'Ngọc', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'ngoc.np.63cntt@ntu.edu.vn', 'phucngoc#256')
insert into KhachHang values('MKH007', N'Nguyễn Dương', N'Ngọc', N'26 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'ngoc.nd.63cntt@ntu.edu.vn', 'duongngoc#256')
insert into KhachHang values('MKH008', N'Nguyễn Phúc', N'Dương', N'26 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 0, 'duong.np.63cntt@ntu.edu.vn', 'phucduong#256')
insert into KhachHang values('MKH009', N'Nguyễn Phúc', N'Trâm', N'26 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'tram.np.63cntt@ntu.edu.vn', 'phuctram#256')
insert into KhachHang values('MKH010', N'Nguyễn Phúc', N'Trang', N'Nha Trang', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'trang.np.63cntt@ntu.edu.vn', 'phuctrang#256')
insert into KhachHang values('MKH011', N'Nguyễn Phúc', N'Nguyệt', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'nguyet.np.63cntt@ntu.edu.vn', 'phucnguyet#256')
insert into KhachHang values('MKH012', N'Trần Phúc', N'Ngọc', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'ngoc.tp.63cntt@ntu.edu.vn', 'tranngoc#256')
insert into KhachHang values('MKH013', N'Trần Huỳnh', N'Trang', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'trang.th.63cntt@ntu.edu.vn', 'huynhtrang#256')
insert into KhachHang values('MKH014', N'Trần Huỳnh', N'Thắng', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'thang.th.63cntt@ntu.edu.vn', 'huynhthang#256')
insert into KhachHang values('MKH015', N'Trần Huỳnh', N'Trúc', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-12-30' AS Date), 1, 'truc.th.63cntt@ntu.edu.vn', 'huynhtruc#256')
insert into KhachHang values('MKH016', N'Trần Huỳnh', N'Nam', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-12-30' AS Date), 1, 'nam.th.63cntt@ntu.edu.vn', 'huynhnam#256')
insert into KhachHang values('MKH017', N'Trần Huỳnh', N'Bắc', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'bac.th.63cntt@ntu.edu.vn', 'huynhbac#256')
insert into KhachHang values('MKH018', N'Trần Huỳnh', N'Thang', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'thang.th.63cntt@ntu.edu.vn', 'huynhthang#256')
insert into KhachHang values('MKH019', N'Trần Nam', N'Trang', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'trang.tn.63cntt@ntu.edu.vn', 'namtrang#256')
insert into KhachHang values('MKH020', N'Trần Chiến', N'Trang', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 0, 'trang.tc.63cntt@ntu.edu.vn', 'chientrang#256')
insert into KhachHang values('MKH021', N'Trần Bắc', N'Trang', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'trang.tb.63cntt@ntu.edu.vn', 'bactrang#256')
insert into KhachHang values('MKH022', N'Trần Hoài', N'Linh', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'linh.th.63cntt@ntu.edu.vn', 'hoailinh#256')
insert into KhachHang values('MKH023', N'Trần Hoài', N'Cẩn', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'can.th.63cntt@ntu.edu.vn', 'hoaican#256')
insert into KhachHang values('MKH024', N'Trần Hoài', N'Thiên', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'thien.th.63cntt@ntu.edu.vn', 'hoaithien#256')
insert into KhachHang values('MKH025', N'Trần Hoài', N'khang', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'khang.th.63cntt@ntu.edu.vn', 'hoaikhang#256')
insert into KhachHang values('MKH026', N'Trần Nam', N'Khang', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 0, 'khang.tn.63cntt@ntu.edu.vn', 'namkhang#256')
insert into KhachHang values('MKH027', N'Trần Khánh', N'Thiên', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'thien.tk.63cntt@ntu.edu.vn', 'khanhthien#256')
insert into KhachHang values('MKH028', N'Trần Hoài', N'Địa', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'dia.th.63cntt@ntu.edu.vn', 'hoaidia#256')
insert into KhachHang values('MKH029', N'Trần Hoài', N'Ma', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'ma.th.63cntt@ntu.edu.vn', 'hoaima#256')
insert into KhachHang values('MKH030', N'Trần địa', N'Thiên', N'25 bùi Huy Bich', '0898753560', CAST(N'2003-11-30' AS Date), 1, 'thien.td.63cntt@ntu.edu.vn', 'diathien#256')


insert into NhanVien values('MNV001', N'Trần Nhựt', N'Trung', '0393967587', 'trung.tn.63cntt@ntu.edu.vn', 0, N'Bùi Huy Bích', 'thientai#257', 'MCV001', CAST(N'2003-03-10' AS Date))
insert into NhanVien values('MNV002', N'Lương Văn', N'Linh', '0392867587', 'linh.lv.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'linh#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV003', N'Bùi Trọng', N'Anh', '0392867587', 'anh.bt.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'anh#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV004', N'Bùi Trọng', N'An', '0392867587', 'an.bt.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'an#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV005', N'Bùi Trọng', N'Hậu', '0392867587', 'hau.bt.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'hau#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV006', N'Bùi Trọng', N'Khang', '0392867587', 'khang.bt.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'khang#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV007', N'Nguyễn Chí', N'Hậu', '0392867587', 'hau.nc.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'chihau#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV008', N'Nguyễn Chí', N'Thành', '0392867587', 'thanh.nc.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'chithanh#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV009', N'Nguyễn Chí', N'Công', '0392867587', 'cong.nc.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'chicong#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV010', N'Nguyễn Thắng', N'Thành', '0392867587', 'thanh.nt.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'thangthanh#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV011', N'Nguyễn Công', N'Phương', '0392867587', 'phuong.nc.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'congphuong#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV012', N'Nguyễn Công', N'Tài', '0392867587', 'tai.nc.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'congtaig#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV013', N'Nguyễn Công', N'Thương', '0392867587', 'thuong.nc.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'congthuong#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV014', N'Nguyễn Công', N'Tráng', '0392867587', 'thuong.nc.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'congtrang#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV015', N'Trần Ngọc Phương', N'Anh', '0392867587', 'anh.tnp.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'phuonganh#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV016', N'Trần Khánh', N'Ngọc', '0392867587', 'ngoc.tk.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'khanhngoc#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV017', N'Trần Khánh', N'Trang', '0392867587', 'trang.tk.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'khanhtrang#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV018', N'Trần Ngọc', N'Trang', '0392867587', 'trang.tn.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'ngoctrang#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV019', N'Trần Ngọc', N'Phong', '0392867587', 'phong.tn.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'ngocphong#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV020', N'Lương Ngọc', N'Trang', '0392867587', 'trang.ln.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'luongtrang#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV021', N'Lương Văn', N'Trang', '0392867587', 'trang.lv.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'vantrang#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV022', N'Lương Ngọc', N'Bích', '0392867587', 'bich.ln.63cntt@ntu.edu.vn', 0, N'2 tháng tư', 'ngocbich#257', 'MCV002', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV023', N'Lương Ngọc', N'Tuyết', '0392867587', 'tuyet.ln.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'ngoctuyet#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV024', N'Huỳnh Thị Ngọc', N'Tuyết', '0392867587', 'tuyet.htn.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'huynhtuyet#257', 'MCV001', CAST(N'2003-07-15' AS Date))
insert into NhanVien values('MNV025', N'Lương Thị', N'Tuyết', '0392867587', 'tuyet.lt.63cntt@ntu.edu.vn', 1, N'2 tháng tư', 'thituyet#257', 'MCV001', CAST(N'2003-07-15' AS Date))

insert into GioHang values('MDH001', CAST(N'2023-11-23' AS Date), 'MKH001', 'MNV003', '0898753560', N'25 Trần Phú', 'thanh.nhm.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH002', CAST(N'2023-11-23' AS Date), 'MKH002', 'MNV003', '0898753560', N'25 Trần Phú', 'sy.np.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH003', CAST(N'2023-11-23' AS Date), 'MKH005', 'MNV003', '0898753560', N'25 Trần Phú', 'sy.nt.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH004', CAST(N'2023-11-23' AS Date), 'MKH005', 'MNV011', '0898753560', N'25 Trần Phú', 'sy.nt.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH005', CAST(N'2023-11-23' AS Date), 'MKH006', 'MNV011', '0898753560', N'25 Trần Phú', 'ngoc.np.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH006', CAST(N'2023-11-23' AS Date), 'MKH007', 'MNV011', '0898753560', N'25 Trần Phú', 'ngoc.nd.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH007', CAST(N'2023-11-23' AS Date), 'MKH011', 'MNV003', '0898753560', N'25 Trần Phú', 'nguyet.np.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH008', CAST(N'2023-11-23' AS Date), 'MKH012', 'MNV003', '0898753560', N'25 Trần Phú', 'ngoc.tp.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH009', CAST(N'2023-11-23' AS Date), 'MKH013', 'MNV003', '0898753560', N'25 Trần Phú', 'trang.th.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH010', CAST(N'2023-11-23' AS Date), 'MKH003', 'MNV003', '0898753560', N'25 Trần Phú', 'tuyen.np.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH011', CAST(N'2023-11-23' AS Date), 'MKH003', 'MNV011', '0898753560', N'25 Trần Phú', 'tuyen.np.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH012', CAST(N'2023-11-23' AS Date), 'MKH017', 'MNV011', '0898753560', N'25 Trần Phú', 'bac.th.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH013', CAST(N'2023-11-23' AS Date), 'MKH020', 'MNV011', '0898753560', N'25 Trần Phú', 'trang.tc.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH014', CAST(N'2023-11-23' AS Date), 'MKH020', 'MNV003', '0898753560', N'25 Trần Phú', 'trang.tc.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH015', CAST(N'2023-11-23' AS Date), 'MKH021', 'MNV003', '0898753560', N'25 Trần Phú', 'trang.tb.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH016', CAST(N'2023-11-23' AS Date), 'MKH022', 'MNV003', '0898753560', N'25 Trần Phú', 'linh.th.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH017', CAST(N'2023-11-23' AS Date), 'MKH023', 'MNV003', '0898753560', N'25 Trần Phú', 'can.th.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH018', CAST(N'2023-11-23' AS Date), 'MKH012', 'MNV003', '0898753560', N'25 Trần Phú', 'ngoc.tp.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH019', CAST(N'2023-11-23' AS Date), 'MKH026', 'MNV003', '0898753560', N'25 Trần Phú', 'khang.tn.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH020', CAST(N'2023-11-23' AS Date), 'MKH025', 'MNV003', '0898753560', N'25 Trần Phú', 'khang.th.63cntt@ntu.edu.vn', 0)
insert into GioHang values('MDH021', CAST(N'2023-11-23' AS Date), 'MKH018', 'MNV003', '0898753560', N'25 Trần Phú', 'thang.th.63cntt@ntu.edu.vn', 0)

insert into ChiTietGioHang values('MCT001', 'MDH001', 'MSS001', 3, 900000, 300000)
insert into ChiTietGioHang values('MCT002', 'MDH002', 'MSS001', 3, 900000, 300000)
insert into ChiTietGioHang values('MCT003', 'MDH003', 'MSS005', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT004', 'MDH004', 'MSS003', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT005', 'MDH005', 'MSS006', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT006', 'MDH006', 'MSS003', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT007', 'MDH007', 'MSS010', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT008', 'MDH008', 'MSS010', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT009', 'MDH009', 'MSS011', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT010', 'MDH010', 'MSS012', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT011', 'MDH011', 'MSS013', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT012', 'MDH012', 'MSS013', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT013', 'MDH013', 'MSS015', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT014', 'MDH014', 'MSS016', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT015', 'MDH015', 'MSS005', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT016', 'MDH016', 'MSS007', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT017', 'MDH017', 'MSS015', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT018', 'MDH018', 'MSS020', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT019', 'MDH019', 'MSS018', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT020', 'MDH020', 'MSS015', 2, 840000, 420000)
insert into ChiTietGioHang values('MCT021', 'MDH021', 'MSS015', 2, 840000, 420000)