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
        private static MyDatabase_SingleTon instance;
        private MyDatabase_SingleTon(bool winNT)
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

        private SqlConnection conn;
        static bool winNT = false;
        private string connectString = string.Empty;
        string err = string.Empty;

        public bool WinNT
        {
            get { return winNT; }
            set { winNT = value; }
        }
        public string ConnectString
        {
            get { return connectString; }
            set { connectString = value; }
        }
        public static MyDatabase_SingleTon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyDatabase_SingleTon(winNT);
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
