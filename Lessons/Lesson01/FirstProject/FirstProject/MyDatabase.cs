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
        public MyDatabase(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }
        public bool CheckConnectToSql(ref string err)
        {
            try
            {
                //Kiểm tra trạng thái kết nối của đối tượng SqlConnection
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
            //kết nối luôn luôn được đóng trong mọi trường hợp
            finally { conn.Close(); }
        }
    }
}
