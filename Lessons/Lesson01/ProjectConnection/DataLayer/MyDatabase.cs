using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class MyDatabase
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private string connectionString = string.Empty;

        public MyDatabase(string connectionString)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }
        public bool CheckConnect(ref string err)
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

        //Phuong thuc lay data (select)
        public SqlDataReader GetDataReader(ref string err, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            SqlDataReader result = null;
            try
            {
                //1. buoc 1- mo ket noi
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                //2  buoc 2: Khoi tao SqlCommand
                cmd = new SqlCommand(commandText, conn);
                cmd.CommandType = commandType;
                cmd.CommandTimeout = 3600;
                if (sqlParameters != null)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                //3. thuc thi command
                result = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                err = ex.Message;

            }

            return result;
        }
    }
}
