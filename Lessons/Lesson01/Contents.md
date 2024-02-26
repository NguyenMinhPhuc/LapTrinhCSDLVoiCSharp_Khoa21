### Nội dung bài học

- Giới thiệu ADO.NET
  - Lịch sử
  - Kiến trúc của ADO.NET
  - Thành phần của ADO.NET
    - SqlConnection
    - SqlCommand
- Ví dụ:
  - Xậy dựng ứng dụng windows form Application để kết nối đến Sql Server.
  - Áp dụng tách lớp MyDatabase
  - Áp dụng design pattern Single Ton để tạo đối tượng kết nối
  - Thực hiện from đổi chuối kết nối cho project.
Template

--CREATE DATABASE <Tên DATABASE>\
GO
--CREATE TABLE <Ten Bang>(<Thuocj tính>)
GO
--Cách viết Store procedure
--1. Thủ tục truy vấn
--lấy tất cả ; lấy theo ID

CREATE PROC PSP_SinhVien_Select @MSSV CHAR(9) = '000000000'
AS
SELECT [MSSV],
       [HoTenSV],
       [NgaySinh],
       [MaLop]
FROM dbo.SinhVien
WHERE IsDelete=0 and @MSSV = CASE @MSSV
                  WHEN '000000000' THEN
                      '000000000'
                  ELSE
                      MSSV
              END;
			  GO

--Template insert and Update
CREATE PROC PSP_SinhVien_InsertAndUpdate
@MSSV CHAR(9),
@HoTenSV NVARCHAR(100),
@NgaySinh date,
@MaLop INT
AS
IF EXISTS (SELECT 1 FROM dbo.SinhVien WHERE MSSV=@MSSV)
BEGIN
    UPDATE dbo.SinhVien
	SET HoTenSV=@HoTenSV,
	NgaySinh=@NgaySinh,
	MaLop=@MaLop
	WHERE MSSV=@MSSV
END
ELSE
BEGIN
    INSERT INTO SinhVien([MSSV], [HoTenSV], [NgaySinh], [MaLop])
	VALUES(@MSSV, @HoTenSV, @NgaySinh, @MaLop)
END
GO
CREATE PROC PSP_SinhVien_Delete
@MSSV CHAR(9)
AS
UPDATE dbo.SinhVien
SET IsDelete=1
WHERE MSSV=@MSSV
--Khong dung
--DELETE dbo.SinhVien
--WHERE MSSV=@MSSV