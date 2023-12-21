using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectConnection.ChiaLop
{
    public class MyDatabase
    {
        private SqlConnection conn;
        private string connectionString = string.Empty;

        public MyDatabase(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        public bool CheckConnect(ref string err)
        {
            try
            {
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
