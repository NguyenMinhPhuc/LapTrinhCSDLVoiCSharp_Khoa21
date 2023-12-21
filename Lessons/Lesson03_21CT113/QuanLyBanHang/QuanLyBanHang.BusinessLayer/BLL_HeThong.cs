using QuanLyBanHang.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BusinessLayer
{
    public class BLL_HeThong : BLL_Base
    {

        public BLL_HeThong() : base()
        {

        }
        public DataTable GetUsers(ref string err)
        {
            return _db.GetDataTable(ref err, "select * from nhanvien", CommandType.Text, null);
        }
        public DataTable GetUserByID(ref string err, string id)
        {
            return _db.GetDataTable(ref err, "PSP_NhanVien231220", CommandType.StoredProcedure, new SqlParameter("@MaNhanVien", id));
        }
        public BLL_HeThong(string path) : base(path)
        {
            _db = new MyDatabase(path);
        }

        public bool CheckConnnect(ref string err)
        {
            return _db.CheckConnect(ref err);
        }
        public SqlConnectionStringBuilder ReadConnectionString(string path)
        {
            SqlConnectionStringBuilder result = null;
            ConnectionStringManager.Instance.ReadConnectionString(path);
            result = ConnectionStringManager.Instance._SqlConnectionStringBuilder;
            return result;
        }

        public void WriteConnectionString(SqlConnectionStringBuilder sqlConnectionStringBuilder, string path)
        {
            ConnectionStringManager.Instance._SqlConnectionStringBuilder = sqlConnectionStringBuilder;
            ConnectionStringManager.Instance.WriteConnectionString(path);
        }
        public void WriteConnectionString(string path, SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            ConnectionStringManager.Instance.WriteConnectionString(path, sqlConnectionStringBuilder);
        }
    }
}
