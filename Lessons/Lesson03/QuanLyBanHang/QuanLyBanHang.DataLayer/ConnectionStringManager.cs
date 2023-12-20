using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DataLayer
{
    //Single ton Design Pattern
    public class ConnectionStringManager
    {
        private static ConnectionStringManager instance;
        //Quản lý chuỗi kết nối
        SqlConnectionStringBuilder myConnectionStringBuilder;
        public SqlConnectionStringBuilder MyConnectionStringBuilder
        {
            get
            {
                return myConnectionStringBuilder;
            }
            set { myConnectionStringBuilder = value; }
        }
        public static ConnectionStringManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnectionStringManager();
                return instance;
            }
        }
        private ConnectionStringManager()
        {
            myConnectionStringBuilder = new SqlConnectionStringBuilder();
        }
        //2 Method
        //1. Đọc chuỗi kết nối từ file Connection.ini
        public void ReadConnectionString(ref string err, string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line = string.Empty;
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Trim();
                            string[] strings = line.Split('=');
                            //strings[0]==>server
                            switch (strings[0].ToLower().Trim())
                            {
                                case "server":
                                    myConnectionStringBuilder.DataSource = strings[1];
                                    break;
                                case "database":
                                    myConnectionStringBuilder.InitialCatalog = strings[1];
                                    break;
                                case "uid":
                                    myConnectionStringBuilder.UserID = strings[1];
                                    break;
                                case "pwd":
                                    myConnectionStringBuilder.Password = strings[1];
                                    break;
                                case "winnt":
                                    myConnectionStringBuilder.IntegratedSecurity = Convert.ToBoolean(strings[1]);
                                    break;
                            }
                        }

                    }
                }
            }
            else
            {
                err = "File không tồn tài";
            }
        }
        //2. Ghi chuỗi kết nối vào file Connection.ini
        public void WriteConnectionString(ref string err, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(string.Format("server={0}", myConnectionStringBuilder.DataSource));
                    sw.WriteLine(string.Format("database={0}", myConnectionStringBuilder.InitialCatalog));
                    sw.WriteLine(string.Format("uid={0}", myConnectionStringBuilder.UserID));
                    sw.WriteLine(string.Format("pwd={0}", myConnectionStringBuilder.Password));
                    sw.WriteLine(string.Format("winnt={0}", myConnectionStringBuilder.IntegratedSecurity.ToString()));
                }
            }
        }
        public void WriteConnectionString(ref string err, string path, SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(string.Format("server={0}", sqlConnectionStringBuilder.DataSource));
                    sw.WriteLine(string.Format("database={0}", sqlConnectionStringBuilder.InitialCatalog));
                    sw.WriteLine(string.Format("winnt={0}", sqlConnectionStringBuilder.IntegratedSecurity.ToString()));
                    sw.WriteLine(string.Format("uid={0}", sqlConnectionStringBuilder.UserID));
                    sw.WriteLine(string.Format("pwd={0}", sqlConnectionStringBuilder.Password));

                }
            }
        }
    }
}
