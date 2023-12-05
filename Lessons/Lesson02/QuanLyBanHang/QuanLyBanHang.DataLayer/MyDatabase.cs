using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
//ADO.NET Framework

namespace QuanLyBanHang.DataLayer
{
    public class MyDatabase
    {
        // Connection
        SqlConnection sqlConnection;
        // Command
        SqlCommand cmd;
        // DataReader

        // DataAdapter
        SqlDataAdapter dataAdapter;
        string connectionString = string.Empty;//"Server=MINHPHUC\\MSSQL2019;database=Data_BanHang_HocTap;uid=sa;pwd=infor210385";

        public MyDatabase(string path)
        {
            ConnectionStringManager.Instance.ReadConnectionString(path);
            connectionString = ConnectionStringManager.Instance.ConnectionStringBuilder.ConnectionString;
            this.sqlConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Phương thức kiểm tra kết nối đến Sql Server
        /// </summary>
        /// <param name="err">Biến tham chiếu lưu lỗi (nếu có)</param>
        /// <returns> trạng thái true khi kết nối thành công, false kết nối không không thành công</returns>
        public bool CheckConnection(ref string err)
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        //1. Thực hiện Select (Lấy về DataTable, DataReader, Object, XML Document)
        public DataTable GetDataTable(ref string err, string sqlCommandtext, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            DataTable dataTable = null;
            try
            {
                //1. ket noi
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();

                //2. command
                cmd = new SqlCommand(sqlCommandtext, sqlConnection);
                cmd.CommandType = commandType;
                cmd.CommandTimeout = 3600;

                if (sqlParameters != null)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                //3. Thuc thi command
                dataAdapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally { sqlConnection.Close(); }
            return dataTable;
        }

        public SqlDataReader GetSqlDataReader(ref string err, string sqlCommandtext, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                //1. ket noi
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();

                //2. command
                cmd = new SqlCommand(sqlCommandtext, sqlConnection);
                cmd.CommandType = commandType;
                cmd.CommandTimeout = 3600;

                if (sqlParameters != null)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                //3. Thuc thi command
                sqlDataReader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return sqlDataReader;
        }

        public Object GetObject(ref string err, string sqlCommandtext, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            Object obj = null;
            try
            {
                //1. ket noi
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();

                //2. command
                cmd = new SqlCommand(sqlCommandtext, sqlConnection);
                cmd.CommandType = commandType;
                cmd.CommandTimeout = 3600;

                if (sqlParameters != null)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                //3. Thuc thi command
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally { sqlConnection.Close(); }
            return obj;
        }

        public XmlReader GetXMLReader(ref string err, string sqlCommandtext, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            XmlReader obj = null;
            try
            {
                //1. ket noi
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();

                //2. command
                cmd = new SqlCommand(sqlCommandtext, sqlConnection);
                cmd.CommandType = commandType;
                cmd.CommandTimeout = 3600;

                if (sqlParameters != null)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                //3. Thuc thi command
                obj = cmd.ExecuteXmlReader();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally { sqlConnection.Close(); }
            return obj;
        }

        //2. Thực hiện các thao tác dữ liệu (insert , update, delete)

        public int MyExcuteNonQuery(ref string err, string sqlCommandtext, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            int count = 0;
            try
            {
                //1. ket noi
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();

                //2. command
                cmd = new SqlCommand(sqlCommandtext, sqlConnection);
                cmd.CommandType = commandType;
                cmd.CommandTimeout = 3600;

                if (sqlParameters != null)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                //3. Thuc thi command
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally { sqlConnection.Close(); }
            return count;
        }
    }
}
