using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class MyDatabase
    {
        private SqlConnection conn;

        private string connectString = string.Empty;
        string err = string.Empty;

        public string ConnectString
        {
            get { return connectString; }
            set { connectString = value; }
        }
        public MyDatabase(bool winNT)
        {
            if (winNT)
            {
                ConnectString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;Integrated security=true;";
            }
            else
            {
                ConnectString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;uid=sa;pwd=infor210385;";
            }
            conn = new SqlConnection(ConnectString);
        }

        public bool CheckConnectToSql(ref string err)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            finally { conn.Close(); }
        }


    }
}
