using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DataLayer
{
    public class ConnectionStringManager
    {
        private static ConnectionStringManager instance;
        private SqlConnectionStringBuilder connectionStringBuilder;
        private ConnectionStringManager()
        {
            ConnectionStringBuilder = new SqlConnectionStringBuilder();
        }
        public static ConnectionStringManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionStringManager();
                }
                return instance;
            }
        }

        public SqlConnectionStringBuilder ConnectionStringBuilder
        {
            get
            {
                return connectionStringBuilder;
            }
            set
            {
                connectionStringBuilder = value;
            }
        }

        public void ReadConnectionString(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim(); //server=MINHPHUC\MSSQL2019
                        string[] strings = line.Split(new char[] { '=' });
                        switch (strings[0])
                        {
                            case "server":
                                ConnectionStringBuilder.DataSource = strings[1];
                                break;
                            case "database":
                                ConnectionStringBuilder.InitialCatalog = strings[1];//database
                                break;
                            case "uid":
                                ConnectionStringBuilder.UserID = strings[1];//user name
                                break;
                            case "pwd":
                                ConnectionStringBuilder.Password = strings[1];//password
                                break;
                            case "winnt":
                                ConnectionStringBuilder.IntegratedSecurity = Convert.ToBoolean(strings[1]);//winnt
                                break;
                        }
                    }
                }
            }
        }

        public void WriteConnectionString(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(string.Format("server={0}", ConnectionStringBuilder.DataSource));
                    sw.WriteLine(string.Format("database={0}", ConnectionStringBuilder.InitialCatalog));
                    sw.WriteLine(string.Format("uid={0}", ConnectionStringBuilder.UserID));
                    sw.WriteLine(string.Format("pwd={0}", ConnectionStringBuilder.Password));
                    sw.WriteLine(string.Format("winnt={0}", ConnectionStringBuilder.IntegratedSecurity.ToString()));
                }
            }

        }
    }
