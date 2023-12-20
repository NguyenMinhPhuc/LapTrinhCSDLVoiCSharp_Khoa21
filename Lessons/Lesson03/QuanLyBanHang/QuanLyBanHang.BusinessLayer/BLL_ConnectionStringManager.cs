using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DataLayer;

namespace QuanLyBanHang.BusinessLayer
{
    public class BLL_ConnectionStringManager
    {

        public BLL_ConnectionStringManager()
        {

        }

        public SqlConnectionStringBuilder ReadConnectionString(ref string err, string path)
        {
            ConnectionStringManager.Instance.ReadConnectionString(ref err, path);
            return ConnectionStringManager.Instance.MyConnectionStringBuilder;
        }

        public void WriteConnectionString(ref string err, string path, SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            ConnectionStringManager.Instance.WriteConnectionString(ref err, path, sqlConnectionStringBuilder);
        }

    }
}
