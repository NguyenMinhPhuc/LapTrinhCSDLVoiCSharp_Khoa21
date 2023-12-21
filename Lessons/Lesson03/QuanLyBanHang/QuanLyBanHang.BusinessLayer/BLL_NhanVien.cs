using QuanLyBanHang.DataLayer;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BusinessLayer
{
    public class BLL_NhanVien : BLL_Base
    {

        public BLL_NhanVien(string path) : base(path) { }
        public DataTable GetNhanViens(ref string err)
        {
            return myDatabase.GetDataTable(ref err, "Select * from NhanVien", CommandType.Text, null);
        }
        public DataTable GetAllNhanVien(ref string err)
        {
            return myDatabase.GetDataTable(ref err, "PSP_NhanVien_Select", CommandType.StoredProcedure, null);
        }
        public DataTable GetNhanVienByID(ref string err, string maNhanVien)
        {

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("thamso ",9)
            };
            return myDatabase.GetDataTable(ref err, "PSP_NhanVien_Select", CommandType.StoredProcedure, sqlParameters);
        }

        public int Insert(ref string err, NhanVien nhanVien)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", nhanVien.MaNhanVien),
                new SqlParameter("@TenDangNhap", nhanVien.TenDangNhap),
                new SqlParameter("@NgaySinh", nhanVien.NgaySinh),
                new SqlParameter("@DienThoai", nhanVien.DienThoai),
                new SqlParameter("@MaTaiKhoan", nhanVien.MaTaiKhoan),
                new SqlParameter("@TenDangNhap", nhanVien.TenDangNhap),
                new SqlParameter("@MatKhau", nhanVien.MatKhau)
            };
            return myDatabase.MyExcuteNonQuery(ref err, "PSP_NhanVien_InsertUpdate", CommandType.StoredProcedure, sqlParameters);
        }

    }
}
