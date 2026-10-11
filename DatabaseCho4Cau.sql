CREATE DATABASE ThucHanh_EFCore_Chuong8;
GO

USE ThucHanh_EFCore_Chuong8;
GO

-- Câu 1: Quản lý thể loại sách
CREATE TABLE TheLoaiSach (
    MaTL INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255) NULL,
    SoLuongSach INT DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE()
);

INSERT INTO TheLoaiSach (TenTheLoai, MoTa, SoLuongSach) VALUES
(N'Công nghệ thông tin', N'Sách lập trình, phần mềm, mạng máy tính', 15),
(N'Kinh tế', N'Quản trị kinh doanh, tài chính, đầu tư', 8),
(N'Văn học', N'Tiểu thuyết, truyện ngắn trong và ngoài nước', 20);
GO

-- Câu 2: Quản lý hội viên
CREATE TABLE HoiVien (
    MaHV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh BIT NOT NULL,
    NgaySinh DATE NOT NULL,
    SDT VARCHAR(15) NULL,
    Email VARCHAR(100) NULL,
    HangThanhVien NVARCHAR(20) NOT NULL,
    NgayDangKy DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1
);

INSERT INTO HoiVien (HoTen, GioiTinh, NgaySinh, SDT, Email, HangThanhVien, TrangThai) VALUES
(N'Nguyễn Văn An', 1, '2000-05-15', '0912345678', 'vana@gmail.com', N'VIP', 1),
(N'Trần Thị Bích', 0, '2002-10-20', '0987654321', 'thib@gmail.com', N'Basic', 1),
(N'Lê Hoàng Nam', 1, '1998-12-01', '0905123456', 'namlh@gmail.com', N'Standard', 1),
(N'Phạm Thu Hà', 0, '2001-07-25', '0934567890', 'hapham@gmail.com', N'VIP', 0);
GO

-- Câu 3: Quản lý phòng
CREATE TABLE LoaiPhong (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    GiaMoiDem DECIMAL(18,2) NOT NULL,
    MoTa NVARCHAR(255) NULL
);

CREATE TABLE Phong (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong VARCHAR(10) NOT NULL,
    TangSo INT NOT NULL,
    TinhTrang NVARCHAR(20) DEFAULT N'Trống',
    HinhAnh NVARCHAR(255) NULL,
    MaLoai INT NOT NULL,
    CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai)
);

INSERT INTO LoaiPhong (TenLoai, GiaMoiDem, MoTa) VALUES
(N'Standard', 500000, N'Phòng tiêu chuẩn 1 giường đôi'),
(N'Deluxe', 800000, N'Phòng cao cấp hướng view đẹp'),
(N'VIP Suite', 1500000, N'Phòng thượng hạng đầy đủ tiện nghi');

INSERT INTO Phong (SoPhong, TangSo, TinhTrang, HinhAnh, MaLoai) VALUES
('101', 1, N'Trống', 'room101.jpg', 1),
('102', 1, N'Đã thuê', 'room102.jpg', 1),
('201', 2, N'Trống', 'room201.jpg', 2),
('301', 3, N'Trống', 'room301.jpg', 3);
GO

-- Câu 4: Quản lý lịch khám
CREATE TABLE BacSi (
    MaBS INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NULL
);

CREATE TABLE LichKham (
    MaLich INT IDENTITY(1,1) PRIMARY KEY,
    MaBS INT NOT NULL,
    TenBenhNhan NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NULL,
    NgayKham DATE NOT NULL,
    GioKham NVARCHAR(10) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Chờ khám',
    CONSTRAINT FK_LichKham_BacSi FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS)
);

INSERT INTO BacSi (HoTen, ChuyenKhoa, SDT) VALUES
(N'BS. Nguyễn Văn Hùng', N'Nội khoa', '0901234567'),
(N'BS. Lê Thị Mai', N'Nhi khoa', '0908765432');

INSERT INTO LichKham (MaBS, TenBenhNhan, SDT, NgayKham, GioKham, TrangThai) VALUES
(1, N'Phạm Văn Cường', '0911223344', CAST(GETDATE() AS DATE), '08:30', N'Chờ khám'),
(2, N'Đỗ Thị Duyên', '0933445566', CAST(GETDATE() AS DATE), '09:15', N'Đã khám');
GO
