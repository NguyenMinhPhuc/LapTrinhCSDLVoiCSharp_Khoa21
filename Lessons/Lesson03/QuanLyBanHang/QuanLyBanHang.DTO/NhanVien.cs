using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class NhanVien
    {
        string maNhanVien, tenNhanVien, dienThoai, tenDangNhap, matKhau, maTaiKhoan;
        bool gioiTinh, tinhTrang;
        DateTime ngaySinh;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
    }
}
