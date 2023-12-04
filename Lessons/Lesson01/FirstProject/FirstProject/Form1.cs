using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;


namespace FirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region bo
        ////field
        //private SqlConnection conn;
        //private string connectString = string.Empty;
        #endregion
        bool winNT = false;
        string err = string.Empty;
        MyDatabase myDatabase;
        private void Form1_Load(object sender, EventArgs e)
        {
            // myDatabase = new MyDatabase(winNT);
            this.Text = MyDatabase_SingleTon.Instance.ConnectString;
            // KhoiTaoLaiChuoiKetNoi();
        }
        #region bo
        //private void KhoiTaoLaiChuoiKetNoi()
        //{
        //    if (winNT)
        //    {
        //        connectString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;Integrated security=true;";
        //    }
        //    else
        //    {
        //        connectString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;uid=sa;pwd=infor210385;";
        //    }
        //    conn = new SqlConnection(connectString);
        //    this.Text = connectString;
        //}
        //private bool CheckConnectToSql(ref string err)
        //{
        //    try
        //    {
        //        if (conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        conn.Open();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        err = ex.Message;
        //        return false;
        //    }
        //    finally { conn.Close(); }
        //}
        #endregion
        private void btnConnectToSQL_Click(object sender, EventArgs e)
        {
            if (MyDatabase_SingleTon.Instance.CheckConnectToSql(ref err))
            {
                MessageBox.Show("Kết nối thành công đến SQL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kết nối không thành công đến SQL do: \n " + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbWinNT_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbWinNT.Checked)
            {
                winNT = true;
                MyDatabase_SingleTon.Instance.WinNT = winNT;
                // myDatabase = new MyDatabase(winNT);
            }
            else
            {
                winNT = false;
                MyDatabase_SingleTon.Instance.WinNT = winNT;
                // myDatabase = new MyDatabase(winNT);
            }
            this.Text = MyDatabase_SingleTon.Instance.ConnectString;

        }
    }
}
