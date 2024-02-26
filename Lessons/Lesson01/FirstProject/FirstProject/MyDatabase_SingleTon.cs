using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FirstProject
{
    public class MyDatabase_SingleTon
    {
        private SqlConnection conn;
        static bool winNT = false;
        private static string connectionString = string.Empty;
        string err = string.Empty;

        private static MyDatabase_SingleTon instance;
        private MyDatabase_SingleTon(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }
        public bool WinNT
        {
            get { return winNT; }
            set { winNT = value; }
        }
        public string ConnectString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public static MyDatabase_SingleTon Instance
        {
            get
            {
                if (instance == null)
                {
                    if (winNT)
                    {
                        connectionString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;Integrated security=true;";
                    }
                    else
                    {
                        connectionString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;uid=sa;pwd=infor210385;";
                    }
                    instance = new MyDatabase_SingleTon(connectionString);
                }
                return instance;
            }
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
